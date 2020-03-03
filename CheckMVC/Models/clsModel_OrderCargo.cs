using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMVC.Models
{
    public class clsModel_OrderCargo
    {
        public int OrderID { get; set; }
        public string Quantity { get; set; }
        public string WarehousePlace { get; set; }
    }
}