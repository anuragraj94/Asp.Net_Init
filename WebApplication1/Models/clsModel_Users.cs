using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class clsModel_Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// Admin Model
    /// </summary>
    public class clsModel_AddwareHouse
    {
        public int ID { get; set; }
        public string Place { get; set; }
        public string SupervisorName { get; set; }
        public int Capacity { get; set; }
        public string MobileNumber { get; set; }
    }
    public  class clsModel_OrderCargo
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string WarehousePlace { get; set; }
    }
    public class clsModel_ShiftOrder
    {
        public int OrderId { get; set; }
        public string ShiftFrom { get; set; }
        public int QuantityOrdered { get; set; }
        public string ShiftTo { get; set; }
        public int Capacity { get; set; }
        public int QuantityInWarehouse { get; set; }
    }
    
    /*
     User Model
     */

}