using CheckMVC.BLL;
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
        /*[HttpPost]
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
                DefaultBll _DefaultBll = new DefaultBll();
                var data = _DefaultBll.logIn(logIn);
                if (data==1)
                {
                    return RedirectToAction("AddWareHouse", "Admin");
                }
                else if (data==2)
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
        }*/

        [HttpPost]
        public JsonResult _LogIn(Models.logIn logIn)
        {
            if (!ModelState.IsValid)
            {
                return Json("F",JsonRequestBehavior.AllowGet);
            }
            else
            {
                DefaultBll _DefaultBll = new DefaultBll();
                return Json(_DefaultBll.logIn(logIn), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.DataModel data)
        {           
            DefaultBll _DefaultBll = new DefaultBll();
            bool bData = _DefaultBll.CreateUser(data);
            if (bData == true)
            {
                return RedirectToAction("Create");
            }
            return View();
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
            DefaultBll _DefaultBll = new DefaultBll();
            return Json(_DefaultBll.BindTblValidation(), JsonRequestBehavior.AllowGet);
        }
      


        public ActionResult Check()
        {
            return View();
        }
        public ActionResult CH()
        {
            return View();
        }
        [HttpPost]
        public JsonResult tblData(string ID)
        {           
            DefaultBll _DefaultBll = new DefaultBll();
            return Json(_DefaultBll.BindTblData(ID),JsonRequestBehavior.AllowGet);
            //return Json("Name:'Helo'");
        }
        public JsonResult Edit(int Id)
        {
            return Json(null);
        }
        public JsonResult Delete(int Id)
        {
            return Json(null);
        }
        public ActionResult Pagination()
        {
            return View();
        }
    }
}