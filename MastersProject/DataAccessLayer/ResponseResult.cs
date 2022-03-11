using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.DataAccessLayer
{
    public class ResponseResult
    {
        public bool Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string RedirectURL { get; set; }

        public ResponseResult GetResponse(bool status, object data, string message)
        {
            return new ResponseResult { Status = status, Data = data, Message = message };
        }
    }
}