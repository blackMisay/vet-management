using System;
using System.Collections.Generic;
using Core;
using app.core.model;
using System.Data.Common;
using System.Security.Policy;
using System.Xml.Linq;
using System.Windows.Forms;
using app.Core.Model;
using MySqlConnector;

namespace app.core.repository
{
    internal class TransactionPaymentRepository
    {
        public TransactionPaymentRepository() { }
        public bool SavePayment(TransactionPayment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (payment.Client?.Id <= 0)
                throw new ArgumentException("Client Id must be a positive integer.", nameof(payment.Client));

            if (payment.Pet?.Id <= 0)
                throw new ArgumentException("Pet Id must be a positive integer.", nameof(payment.Pet));

            if (payment.Id > 0)
            {
                // Update logic (not implemented here)
                return false;
            }

            string paymentSql = @"
        INSERT INTO transaction_payment (
            client_id, pet_id, cash, gcash, gcashReferenceNo, payMaya, payMayaReferenceNo,
            invoice_number, total, date, `change`
        )
        VALUES (
            @ClientId, @PetId, @Cash, @GCash, @GCashReferenceNumber, @PayMaya,
            @PayMayaReferenceNumber, @InvoiceNumber, @TotalAmount, @Date, @ChangeAmount
        );
        SELECT LAST_INSERT_ID();";

            var paymentParams = new Dictionary<string, object>
    {
        { "@ClientId", payment.Client.Id },
        { "@PetId", payment.Pet.Id },
        { "@Cash", payment.Cash },
        { "@GCash", payment.GCash },
        { "@GCashReferenceNumber", payment.GCashReferenceNumber ?? string.Empty },
        { "@PayMaya", payment.PayMaya },
        { "@PayMayaReferenceNumber", payment.PayMayaReferenceNumber ?? string.Empty },
        { "@InvoiceNumber", payment.InvoiceNumber ?? string.Empty },
        { "@TotalAmount", payment.TotalAmount },
        { "@ChangeAmount", payment.ChangeAmount },
        { "@Date", payment.Date }
    };

            try
            {
                UpgradeFile upgradeFile = new UpgradeFile();
                int paymentId = upgradeFile.ExecuteInsertWithId(paymentSql, paymentParams);

                if (paymentId <= 0)
                {
                    MessageBox.Show("Payment ID not generated.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Save each transaction detail
                foreach (var detail in payment.TransactionDetails)
                {
                    string detailSql = @"
                INSERT INTO transaction_payment_detail (
                    transaction_payment_id, product_id, description, quantity, unit_price, total
                )
                VALUES (
                    @TransactionPaymentId, @ProductId, @Description, @Quantity, @UnitPrice, @TotalAmount
                );";

                    var detailParams = new Dictionary<string, object>
            {
                { "@TransactionPaymentId", paymentId },
                { "@ProductId", detail.ProductId },
                { "@Description", detail.Description ?? string.Empty },
                { "@Quantity", detail.Quantity },
                { "@UnitPrice", detail.UnitPrice },
                { "@TotalAmount", detail.TotalAmount }
            };

                    upgradeFile.Save(detailSql, detailParams);

                    // Deduct stock for this product
                    DeductStock(detail.ProductId, detail.Quantity, upgradeFile);

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save transaction and payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void DeductStock(int productId, int quantity, UpgradeFile upgradeFile)
        {
            if (productId <= 0)
            {
                throw new Exception($"Invalid productId: {productId}. Must be > 0.");
            }

            // Check if product exists
            string checkSql = "SELECT stock FROM products WHERE id = @id;";
            var checkParams = new Dictionary<string, object> { { "@id", productId } };

            object result = upgradeFile.ExecuteScalar(checkSql, checkParams);

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show($"Product not found or stock is NULL. ProductId = {productId}", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Product with ID {productId} not found or stock is NULL.");
            }

            if (!int.TryParse(result.ToString(), out int currentStock))
            {
                MessageBox.Show($"Stock value is invalid: {result}", "Invalid Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Invalid stock value for product ID {productId}: {result}");
            }

            if (currentStock < quantity)
            {
                MessageBox.Show($"Stock too low. Available = {currentStock}, Needed = {quantity}, ProductId = {productId}", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception($"Insufficient stock for product ID {productId}: available={currentStock}, requested={quantity}");
            }

            // Deduct stock
            string deductSql = @"
        UPDATE products
        SET stock = stock - @qty
        WHERE id = @id;";
            var deductParams = new Dictionary<string, object>
    {
        { "@qty", quantity },
        { "@id", productId }
    };

            bool updated = upgradeFile.ExecuteNonQuery(deductSql, deductParams);
            if (!updated)
                throw new Exception($"Failed to deduct stock for product ID {productId}");
        }

        //public bool DeleteHoldOrder(string InvoiceNumber)
        //{

        //    {
        //        UpgradeFile db = new UpgradeFile();
        //        Dictionary<string, string> parameters = new Dictionary<string, string>()
        //        {
        //            { "@InvoiceNumber", InvoiceNumber }
        //        };

        //        return db.Save("DELETE hop FROM holdorderproducts hop JOIN holdorders ho ON hop.holdorderId = ho.holdorderId WHERE ho.transactionNo=@TransactionNumber; DELETE ho FROM holdorders ho WHERE ho.transactionNo=@TransactionNumber;", parameters);
        //    }
        //}

        public TransactionPayment LoadFullPayment(int paymentId)
        {

            if (paymentId <= 0)
                throw new ArgumentException("Invalid Payment ID", nameof(paymentId));

            var upgradeFile = new UpgradeFile();
            var parameters = new Dictionary<string, object> { { "@Id", paymentId } };

            string sqlMain = @"
        SELECT 
            p.id, p.invoice_number, p.total, p.`change`, p.date,
            p.cash, p.gcash, p.gcashReferenceNo, p.payMaya, p.payMayaReferenceNo,
            c.id AS ClientId, c.firstname, c.lastname,
            pet.id AS PetId, pet.name AS PetName
        FROM transaction_payment p
        LEFT JOIN client c ON p.client_id = c.id
        LEFT JOIN patient pet ON p.pet_id = pet.id
        WHERE p.id = @Id";

            var mainResult = upgradeFile.QuerySingle(sqlMain, parameters);

            if (mainResult == null)
            {
                MessageBox.Show($"No payment found for ID {paymentId}.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var payment = new TransactionPayment
            {
                Id = Convert.ToInt32(mainResult["id"]),
                InvoiceNumber = mainResult["invoice_number"]?.ToString(),
                TotalAmount = Convert.ToDouble(mainResult["total"]),
                ChangeAmount = Convert.ToDouble(mainResult["change"]),
                Date = Convert.ToDateTime(mainResult["date"]),
                Cash = Convert.ToDouble(mainResult["cash"]),
                GCash = Convert.ToDouble(mainResult["gcash"]),
                GCashReferenceNumber = mainResult["gcashReferenceNo"]?.ToString(),
                PayMaya = Convert.ToDouble(mainResult["payMaya"]),
                PayMayaReferenceNumber = mainResult["payMayaReferenceNo"]?.ToString(),
                Client = new Client
                {
                    Id = Convert.ToInt32(mainResult["ClientId"]),
                    FirstName = mainResult["firstname"]?.ToString(),
                    LastName = mainResult["lastname"]?.ToString()
                },
                Pet = new Pet
                {
                    Id = Convert.ToInt32(mainResult["PetId"]),
                    Name = mainResult["PetName"]?.ToString()
                }
            };

            // Load transaction details
            string sqlDetails = @"
        SELECT 
            id, transaction_payment_id, product_id, description, quantity, unit_price, total
        FROM transaction_payment_detail
        WHERE transaction_payment_id = @TransactionPaymentId";

            var detailRows = upgradeFile.Query(sqlDetails, parameters);
            payment.TransactionDetails = new List<TransactionDetail>();

            foreach (var row in detailRows)
            {
                var detail = new TransactionDetail
                {
                    Id = Convert.ToInt32(row["id"]),
                    TransactionPaymentId = Convert.ToInt32(row["transaction_payment_id"]),
                    ProductId = Convert.ToInt32(row["product_id"]),
                    Description = row["description"]?.ToString(),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    UnitPrice = Convert.ToDouble(row["unit_price"]),
                    TotalAmount = Convert.ToDouble(row["total"])
                };

                payment.TransactionDetails.Add(detail);
            }

            return payment;

        }
    }
}

