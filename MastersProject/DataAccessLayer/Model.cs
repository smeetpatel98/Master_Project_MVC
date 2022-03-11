using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.DataAccessLayer
{
    public class Model
    {
        ResponseResult responseResult;
        private bool _disposed;
        public Models.Master_MVCEntities context;

        public Model()
        {
            responseResult = new ResponseResult();
            context = new Models.Master_MVCEntities();
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
                }
            }
            _disposed = true;
        }
    }
}