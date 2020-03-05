using CheckMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.Controllers
{
    public class DefaultController : Controller
    {

        MySqlConnection Con;
        MySqlCommand Cmd;
        MySqlDataReader MySqlDataReader;
        MySqlDataAdapter MySqlDataAdapter;
        string ConString, Query;
        DataTable DataTable;

        private string Server;
        private string Database;
        private string Uid;
        private string Password;


        public bool DbConnection()
        {
            try
            {
                Server = "localhost";
                Database = "mvc";
                Uid = "root";
                Password = "";

                ConString = "SERVER=" + Server + ";" + "DATABASE=" +
                Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

                Con = new MySqlConnection(ConString);
                Con.Open();
                Con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Con.Close();
                return false;
            }
        }

        // GET: Default       
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Models.logIn logIn)
        {
            if (!ModelState.IsValid)
            {
                logIn.UserName = String.Empty;
                logIn.Password = String.Empty;
                ViewData["msg"] = "Failed......";
            }
            else
            {
                if (logIn.UserName == "admin" && logIn.Password == "111")
                {
                    return RedirectToAction("AddWareHouse", "Admin");
                }
                else if (logIn.UserName == "Kunal" && logIn.Password == "111")
                {
                    return RedirectToAction("Acceptance", "User");
                }
                else
                {
                    logIn.UserName = String.Empty;
                    logIn.Password = String.Empty;
                    ViewData["msg"] = "Failed......";
                }
            }
            return View(logIn);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.DataModel data)
        {
            if (DbConnection())
            {
                Query = "insert into persons values(@ID,@UserName,@Password,@Email,@Address)";
                Cmd = new MySqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("ID", null);
                Cmd.Parameters.AddWithValue("UserName", data.UserName);
                Cmd.Parameters.AddWithValue("Password", data.Password);
                Cmd.Parameters.AddWithValue("Email", data.Email);
                Cmd.Parameters.AddWithValue("Address", data.Address);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
            }
            return RedirectToAction("Create");
        }
        public ActionResult list()
        {
            return View();
        }

        public ActionResult Serial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Serial(Models.SerialModel serialModel)
        {
            IPAddress LoggerIp = IPAddress.Parse(serialModel.NewIp);
            IPAddress Subnet = IPAddress.Parse(serialModel.Subnet);
            IPAddress NtpIp = IPAddress.Parse(serialModel.NtpIp);
            Setting(serialModel.ComPort, Convert.ToInt32(serialModel.BaudRate), LoggerIp, Subnet, NtpIp);
            AvailPorts();
            return View();
        }

        public string[] AvailPorts()
        {
            string[] sPorts = SerialPort.GetPortNames();
            if (sPorts != null)
            {
                if (sPorts.Length > 0)
                {
                    return sPorts;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        SerialPort port;
        private AutoResetEvent eventAutoReset = (AutoResetEvent)null;
        private byte[] fileData = new byte[256];
        public void Setting(string ComP, int BaRate, IPAddress LoggerIp, IPAddress Subnet, IPAddress NtpIp)
        {
            try
            {
                Stream stream = (Stream)null;
                SerialDataReceivedEventHandler receivedEventHandler = (SerialDataReceivedEventHandler)null;
                int millisecondsTimeout = 10000;
                port = new SerialPort(ComP, BaRate);
                port.DataBits = 8;
                port.Encoding = Encoding.ASCII;
                port.Handshake = Handshake.None;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.ReceivedBytesThreshold = 2;
                port.Open();
                receivedEventHandler = new SerialDataReceivedEventHandler(port_DataReceived);
                port.DataReceived += receivedEventHandler;
                eventAutoReset = new AutoResetEvent(false);
                stream = port.BaseStream;
                stream.ReadTimeout = 60000;

                stream.WriteByte((byte)87);
                stream.WriteByte((byte)15);
                stream.WriteByte((byte)76);


                byte[] addressBytes1 = LoggerIp.GetAddressBytes();
                if (addressBytes1.Length == 4)
                {
                    for (int index = 0; index < 4; ++index)
                        stream.WriteByte(addressBytes1[index]);
                    byte[] addressBytes2 = NtpIp.GetAddressBytes();
                    if (addressBytes2.Length == 4)
                    {
                        for (int index = 0; index < 4; ++index)
                            stream.WriteByte(addressBytes2[index]);
                        byte[] addressBytes3 = Subnet.GetAddressBytes();
                        if (addressBytes3.Length == 4)
                        {
                            for (int index = 0; index < 4; ++index)
                                stream.WriteByte(addressBytes3[index]);
                            if (this.eventAutoReset.WaitOne(millisecondsTimeout, false)) { }
                            port.Close();
                            stream.Close();
                        }
                    }
                }
                TempData["msg"] = "Successful.........";
            }
            catch (Exception)
            {
                TempData["msg"] = "Failed.......";                
            }
        }


        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (this.port.BytesToRead > 0 && this.port.Read(this.fileData, 0, this.fileData.Length) > 0)
                {
                    foreach (int num in this.fileData)
                    {
                        if (num == 90 || num == 2)
                        {
                            this.eventAutoReset.Set();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LCP.err_writer.Write("port_DataReceived : " + ex.Message + "\r\nSource: " + ex.Source + "\r\nTrace: " + ex.StackTrace + "\r\n");
            }
        }
        DataTable dataTable1;
        public ActionResult AjaxCheck()
        {
            return View();
        }
       [HttpPost]
        public JsonResult TblValidation()
        {
            try
            {
                List<clsModel_AddwareHouse> lst = new List<clsModel_AddwareHouse>();
                clsModel_AddwareHouse modelData = new clsModel_AddwareHouse();
                if (DbConnection())
                {
                    dataTable1 = new DataTable();                    
                    Query = "select * from tbl_warehous";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(dataTable1);
                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                    {
                        modelData.ID = Convert.ToInt32(dataTable1.Rows[i]["Warehouse Id"]);
                        modelData.Place = dataTable1.Rows[i]["Place"].ToString();
                        modelData.SupervisorName = dataTable1.Rows[i]["SupervisorName"].ToString();
                        modelData.Capacity = dataTable1.Rows[i]["Capacity"].ToString();
                        modelData.MobileNumber = dataTable1.Rows[i]["MobileNumber"].ToString();
                        lst.Add(modelData);
                    }
                    return Json(lst);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(null);
        }
      
    }
}