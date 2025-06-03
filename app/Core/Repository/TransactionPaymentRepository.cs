using System;
using System.Collections.Generic;
using Core;
using app.core.model;
using System.Data.Common;
using System.Security.Policy;
using System.Xml.Linq;
using System.Windows.Forms;
using app.Core.Model;

namespace app.core.repository
{
    internal class TransactionPaymentRepository
    {
        public TransactionPaymentRepository() { }
        public bool SavePayment(TransactionPayment payment)
        {
            bool isUpdate = payment.Id > 0;
            string sql;

            var parameters = new Dictionary<string, object>
    {
        { "@ClientId", payment.Client.Id},
        { "@PetId", payment.Pet.Id},
        { "@Cash", payment.Cash },
        { "@GCash", payment.GCash },
        { "@GCashReferenceNumber", payment.GCashReferenceNumber ?? string.Empty },
        { "@PayMaya", payment.PayMaya },
        { "@PayMayaReferenceNumber", payment.PayMayaReferenceNumber ?? string.Empty },
        { "@Type", payment.Type ?? string.Empty },
        { "@Name", payment.Name ?? string.Empty },
        { "@InvoiceNumber", payment.InvoiceNumber ?? string.Empty },
        { "@TotalAmount", payment.TotalAmount },
        { "@ChangeAmount", payment.ChangeAmount },
        { "@Date", payment.Date }
    };

            if (isUpdate)
            {
                // Optional: Add update query if needed
                return false;
            }

            sql = @"
        INSERT INTO transaction_payment (
            client_id, pet_id, cash, gcash, gcashReferenceNo, payMaya, payMayaReferenceNo,
            type, name, invoice_number, total, date, `change`
        )
        VALUES (
            @ClientId, @PetId, @Cash, @GCash, @GCashReferenceNumber, @PayMaya,
            @PayMayaReferenceNumber, @Type, @Name, @InvoiceNumber, @TotalAmount, @Date, @ChangeAmount
        ); SELECT LAST_INSERT_ID();";

            try
            {
                UpgradeFile upgradeFile = new UpgradeFile(); // Your DB helper
                int paymentId = upgradeFile.ExecuteInsertWithId(sql, parameters);

                if (paymentId <= 0)
                {
                    return false;
                }

                // Save each payment detail
                foreach (var detail in payment.PaymentDetails)
                {
                    string detailSql = @"
                INSERT INTO payment_detail (
                    transaction_payment_id, mode, reference_number, amount
                )
                VALUES (
                    @TransactionPaymentId, @Mode, @ReferenceNumber, @Amount
                );";

                    var detailParams = new Dictionary<string, object>
            {
                { "@TransactionPaymentId", paymentId },
                { "@Mode", detail.Mode },
                { "@ReferenceNumber", detail.ReferenceNumber ?? string.Empty },
                { "@Amount", detail.Amount }
            };

                    upgradeFile.Save(detailSql, detailParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                MessageBox.Show("Failed to save payment: " + ex.Message);
                return false;
            }
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
            var upgradeFile = new UpgradeFile();
            var payment = new TransactionPayment();

            var parameters = new Dictionary<string, object> { { "@PaymentId", paymentId } };

            string sqlMain = @"
        SELECT p.id, p.invoice_number, p.total, p.`change`, p.date,
               c.id AS ClientId, c.firstname, c.lastname,
               pet.id AS PetId, pet.name AS PetName
        FROM transaction_payment p
        LEFT JOIN client c ON p.client_id = c.id
        LEFT JOIN pet pet ON p.pet_id = pet.id
        WHERE p.id = @PaymentId";

            var mainResult = upgradeFile.QuerySingle(sqlMain, parameters);
            if (mainResult == null)
                return null;

            payment.Id = Convert.ToInt32(mainResult["id"]);
            payment.InvoiceNumber = mainResult["invoice_number"]?.ToString();
            payment.TotalAmount = Convert.ToDouble(mainResult["total"]);
            payment.ChangeAmount = Convert.ToDouble(mainResult["change"]);
            payment.Date = Convert.ToDateTime(mainResult["date"]);

            payment.Client = new Client
            {
                Id = Convert.ToInt32(mainResult["ClientId"]),
                FirstName = mainResult["firstname"]?.ToString(),
                LastName = mainResult["lastname"]?.ToString()
            };

            payment.Pet = new Pet
            {
                Id = Convert.ToInt32(mainResult["PetId"]),
                Name = mainResult["PetName"]?.ToString()
            };

            string sqlPaymentDetails = "SELECT mode, reference_number, amount FROM payment_detail WHERE transaction_payment_id = @PaymentId";
            var paymentDetailsRows = upgradeFile.Query(sqlPaymentDetails, parameters);

            payment.PaymentDetails = new List<PaymentDetail>();
            foreach (var row in paymentDetailsRows)
            {
                payment.PaymentDetails.Add(new PaymentDetail
                {
                    Mode = row["mode"]?.ToString(),
                    ReferenceNumber = row["reference_number"]?.ToString(),
                    Amount = Convert.ToDouble(row["amount"])
                });
            }

            string sqlTransactionDetails = @"
        SELECT item_or_service_id, description, quantity, price
        FROM transaction_detail
        WHERE transaction_payment_id = @PaymentId";

            var transactionDetailsRows = upgradeFile.Query(sqlTransactionDetails, parameters);

            payment.TransactionDetails = new List<TransactionDetail>();
            foreach (var row in transactionDetailsRows)
            {
                payment.TransactionDetails.Add(new TransactionDetail
                {
                    ItemOrServiceId = Convert.ToInt32(row["item_or_service_id"]),
                    Description = row["description"]?.ToString(),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    Price = Convert.ToDouble(row["price"])
                });
            }

            return payment;
        }

    }
}
    

