using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.MSMQ
{
    public class Smtp
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
