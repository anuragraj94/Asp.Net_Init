using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckMVC.Models
{
    public class logIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class DataModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class SerialModel
    {
        [Display(Name ="Logger Name")]
        public string LoggerName { get; set; }
        [Display(Name = "Baut Rate")]
        public string BaudRate { get; set; }
        [Display(Name = "COM Port")]
        public string ComPort { get; set; }
        [Display(Name = "New IP Address")]
        public string NewIp { get; set; }
        [Display(Name = "Subnet Mask")]
        public string Subnet { get; set; }
        [Display(Name = "Gateway")]
        public string Gateway { get; set; }
        [Display(Name = "NTP Server IP")]
        public string NtpIp { get; set; }
    }




    public enum Brate
    {
       Primary=57600,
       other=1212
    }
    public enum Cport
    {
        COM1
    }
    public enum LName
    {
        Logger120,
        Logger150,
        Logger250
    }
}