using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.CoreToken.Domain.Models
{
    public class ResponseApi
    {
        public int StatusCode { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public ResponseApi()
        {
            StatusCode = 200;
            IsError = false;
            Message = "";
            Data = null;
        }
       
    }
}
