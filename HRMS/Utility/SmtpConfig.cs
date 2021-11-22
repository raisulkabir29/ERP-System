using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS
{
    public class SmtpConfig
    {
        public string HostName { set; get; }
        public int Port { set; get; }
        public string UserId { set; get; }
        public string Password { set; get; }
        public bool SSLProtocol { get; set; }
    }
}