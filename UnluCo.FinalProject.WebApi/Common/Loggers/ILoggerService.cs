using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Common.Loggers
{
   public interface ILoggerService
    {
        public void Write(string message);
    }
}
