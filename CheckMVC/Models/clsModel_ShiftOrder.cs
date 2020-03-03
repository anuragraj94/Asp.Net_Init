using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMVC.Models
{
    public class clsModel_ShiftOrder
    {
        public int OrderId { get; set; }
        public string ShiftFrom { get; set; }
        public int QuantityOrdered { get; set; }
        public string ShiftTo { get; set; }
        public int Capacity { get; set; }
        public int QuantityInWarehouse { get; set; }
    }
}