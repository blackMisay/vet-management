using System;
using System.Collections.Generic;
using Core;
using app.core.model;

namespace app.core.repository
{
    internal class TransactionPaymentRepository
    {
        public TransactionPaymentRepository() { }

        public bool Save(TransactionPayment payment)
        {
            string sql = "";
            bool saveState = payment.Id > 0;  // 

            // Prepare parameters for SQL query
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@InvoiceNumber", payment.InvoiceNumber },
                { "@ClientId", payment.Client.Id.ToString() },
                { "@PetId", payment.Pet.Id.ToString() },
                { "@SubTotalAmount", payment.SubTotalAmount.ToString() },
                { "@TotalAmount", payment.TotalAmount.ToString() },
                { "@ChangeAmount", payment.ChangeAmount.ToString() }
            };

            // If updating, use the existing pet Id
            if (!saveState)
            {
                // If inserting, include the client ID
                sql = "INSERT INTO transaction(invoice_number, client_id, pet_id, sub_total_amount, total_amount, change_amount) " +
                      "VALUES(@InvoiceNumber,@ClientId,@PetId,@SubTotalAmount,@TotalAmount,@ChangeAmount);";
            }

            // Execute query
            try
            {
                UpgradeFile upgradeFile = new UpgradeFile();
                bool success = upgradeFile.ExecuteQuery(sql, parameters);
                return success;
            }
            catch (Exception ex)
            {
                // Log or display error if query execution fails
                return false;
            }
        }
    }
}
