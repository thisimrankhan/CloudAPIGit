using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Services
{
    public class AuthMessageSenderOptions
    {
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SMTPServer { get; set; }
        public string APIKey { get; set; }
        public string Port { get; set; }
        public string Host { get; set; }
    }
}
