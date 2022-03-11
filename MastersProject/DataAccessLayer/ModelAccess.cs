using MastersProject.Models;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.DataAccessLayer
{
    public class ModelAccess :IDisposable
    {
        public Master_MVCEntities context;
        private bool _disposed;
        ResponseResult responseResult;
        public ModelAccess()
        {
            responseResult = new ResponseResult();
            context = new Models.Master_MVCEntities();
        }

        public long AddTransactionData(TransactionEntity transactionData)
        {
            bool isUpdate = false;
            var transData = (from t in this.context.tbl_transaction
                             where t.trans_id == transactionData.trans_id
                             select t).FirstOrDefault();
            if (transData == null)
            {
                transData = new tbl_transaction();
            }
            else
            {
                isUpdate = true;
            }
            if (!isUpdate)
            {
                
                transData.created_dt = DateTime.Now;
                transData.created_id = transactionData.Created_id;
                
            }
            if (isUpdate)
            {
                
                transData.last_mod_dt = DateTime.Now;
                transData.last_mod_id = transactionData.Last_mod_id;
            }

            this.context.tbl_transaction.Add(transData);
            if (isUpdate)
            {
                this.context.Entry(transData).State = System.Data.EntityState.Modified;
            }
            this.context.SaveChanges();
            return transData.trans_id;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    // Dispose other managed resources.
                }
                //release unmanaged resources.
            }
            _disposed = true;
        }


    }
}
