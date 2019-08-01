using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMobileNumber
{
    public class APIResponse
    {
        public APIResponse()
        {
            Data = null;
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}