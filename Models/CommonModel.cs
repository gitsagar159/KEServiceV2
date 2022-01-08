using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KEServiceV2.Models
{
    public class CommonModel
    {
    }

    public class APIResponce
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}