using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTD.Models
{
    public class ResultModel
    {
        public bool IsSuccessful { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public bool IsAdmin { get; set; } // Thêm thuộc tính này

    }

}