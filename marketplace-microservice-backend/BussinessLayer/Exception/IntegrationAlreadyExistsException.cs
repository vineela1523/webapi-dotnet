using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.BussinessLayer.Exception
{
    public class IntegrationAlreadyExistsException: ApplicationException
    {
        public IntegrationAlreadyExistsException() { }
        public IntegrationAlreadyExistsException(string message) : base(message) { }
    }
}
