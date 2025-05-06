using System;
using System.Collections.Generic;
using Core;
using app.core.model;
using System.Data.Common;

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
        //public bool SavePayment(TransactionPayment payment)
        //{
        //    using (DBConnection db = new DBConnection())
        //    {
        //        string cash = payment.Cash != 0.0 || payment.Cash != 0 ? payment.Cash.ToString() : "0";
        //        string gcash = payment.GCash != 0.0 || payment.GCash != 0 ? payment.GCash.ToString() : "0";
        //        string gcashRefNo = !string.IsNullOrEmpty(payment.GCashReferenceNumber) ? payment.GCashReferenceNumber : string.Empty;
        //        string payMaya = payment.PayMaya != 0.0 || payment.PayMaya != 0 ? payment.PayMaya.ToString() : "0";
        //        string payMayaRefNo = !string.IsNullOrEmpty(payment.PayMayaReferenceNumber) ? payment.PayMayaReferenceNumber : string.Empty;
        //        string type = !string.IsNullOrEmpty(payment.Type) ? payment.Type : string.Empty;
        //        string name = !string.IsNullOrEmpty(payment.Name) ? payment.Name : string.Empty;
        //        string idNumber = !string.IsNullOrEmpty(payment.IdNumber) ? payment.IdNumber : string.Empty;

        //        Dictionary<string, string> parameters = new Dictionary<string, string>
        //        {
        //            { "@Transaction", payment.Transactions.Id.ToString() },
        //            { "@User", payment.User },
        //            { "@Cash", cash },
        //            { "@GCash", gcash },
        //            { "@GCashRefNo", gcashRefNo },
        //            { "@PayMaya", payMaya },
        //            { "@PayMayaRefNo", payMayaRefNo },
        //            { "@Vatable", payment.Vatable.ToString() },
        //            { "@Vat", payment.Vat.ToString() },
        //            { "@Discount", payment.Discount.ToString() },
        //            { "@Type", type },
        //            { "@Name", name },
        //            { "@IdNumber", idNumber },
        //            { "@Total", payment.TotalCost.ToString() },
        //            { "@ChangeAmount", payment.Change.ToString() }
        //        };

        //        return db.Save(@"INSERT INTO payment(transacId,user,cash,gcash,gcashReferenceNo,payMaya,payMayaReferenceNo,vatable,vat,discount,type,name,idNumber,total,`change`)
        //                    VALUES(@Transaction,@User,@Cash,@GCash,@GCashRefNo,@PayMaya,@PayMayaRefNo,@Vatable,@Vat,@Discount,@Type,@Name,@IdNumber,@Total,@ChangeAmount)", parameters);
        //    }
        //}
    }
        }
    

