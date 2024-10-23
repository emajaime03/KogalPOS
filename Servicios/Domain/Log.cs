using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Services.Domain
{
    public class Log
    {
        public string Message { get; set; }

        public TraceLevel TraceLevel { get; set; }

        public string Usuario { get; set; }

        public Log(string message, string usuario, TraceLevel traceLevel = TraceLevel.Info)
        {
            Message = message;
            TraceLevel = traceLevel;
            Usuario = usuario;
        }
    }
}
