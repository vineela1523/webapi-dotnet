using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.BussinessLayer.Exception;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.Entity;

namespace marketplace_microservice_backend.BussinessLayer
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IIntegration Repository;
        public IntegrationService(IIntegration integration)
        {
            Repository = integration;
        }
        void IIntegrationService.CreateIntegration(EIntegration integration)
        {
            var _integration = Repository.GetIntegrationById(integration.UserId);
            if (_integration == null)
            {
                Repository.CreateIntegration(integration);
            }
            else
            {
                throw new IntegrationAlreadyExistsException($"Integration with Name already exists");
            }
        }


        public EIntegration GetIntegrationByName(string name)
        {

           // return Repository.GetIntegrationByName(name);
            var Gnote = Repository.GetIntegrationByName(name);
            if (Gnote == null)
            {
                throw new IntegrationNotFoundException($"Note with Id{name} not found");
            }
            else
                return Gnote;

        }

        public bool RemoveIntegrationByName(string integrationName)
        {
            var _integrate = Repository.GetIntegrationByName(integrationName);
            if (_integrate == null)
            {
                throw new IntegrationNotFoundException($"Board with id : {integrationName} doesn't exists");
            }
            else
            {
                return Repository.RemoveIntegrationByName(integrationName);
            }
        }
         


        bool IIntegrationService.UpdateIntegration(string integrationName, EIntegration integration)
        {
            var _integration = Repository.GetIntegrationByName(integration.IntegrationName);
            if (_integration == null)
            {
                throw new IntegrationNotFoundException($"Integration with Name not found");
            }
            else
            {
                return Repository.UpdateIntegration(integrationName, integration);
            }
        }

        public EIntegration GetIntegrationById(string id)
        {
            return Repository.GetIntegrationById(id);
        }

        public List<EIntegration> GetAllIntegrations()
        {
            return Repository.GetAllIntegrations();
        }
    }     
}
