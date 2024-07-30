using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patika.WebApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DbLogger] - " + message);
        }
    }
}