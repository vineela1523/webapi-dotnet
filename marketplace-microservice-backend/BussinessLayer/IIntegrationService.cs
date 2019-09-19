using marketplace_microservice_backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.Entity;

namespace marketplace_microservice_backend.BussinessLayer
{
    public  interface IIntegrationService
    {
        EIntegration GetIntegrationById(string id);
       EIntegration GetIntegrationByName(string name);
        void CreateIntegration(EIntegration integration);
        bool RemoveIntegrationByName(string integrationName);
        bool UpdateIntegration(string integrationName, EIntegration integration);
        List<EIntegration> GetAllIntegrations();
    }
}
