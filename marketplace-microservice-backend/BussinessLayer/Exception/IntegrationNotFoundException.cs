using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.BussinessLayer.Exception
{
    public class IntegrationNotFoundException: ApplicationException
    {
        public IntegrationNotFoundException() { }
        public IntegrationNotFoundException(string message) : base(message) { }
    }
}
