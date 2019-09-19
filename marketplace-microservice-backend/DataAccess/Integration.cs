using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.Entity;

namespace marketplace_microservice_backend.DataAccess
{
    public class Integration :IIntegration
    {
         
        private readonly AllDbContext context;
        public Integration(AllDbContext allDbContext)
        {
            context = allDbContext;
        }

        public void CreateIntegration(EIntegration integration)
        {
            context.Integrations.InsertOne(integration);
        }

        public  List<EIntegration> GetAllIntegrations()
        {
            return context.Integrations.Find(_=>true).ToList();
        }

        public EIntegration GetIntegrationById(string id)
        {
            return context.Integrations.Find(i => i.UserId == id).SingleOrDefault();
        }

        public EIntegration GetIntegrationByName(string name)
        {
            //return context.Integrations.Find(d => d.IntegrationName.Equals( name)).FirstOrDefault();
            EIntegration eIntegration = context.Integrations.Find(n=>n.IntegrationName==name).First();
            return eIntegration;
            // return context.Integrations.FindOneById(ObjectId.Parse(id));

            // return contxt.Notes.Find(c => c.NoteId == NoteId).FirstOrDefault();
        }

        public bool RemoveIntegrationByName(string integrationName)
        {
            var deletedResult = context.Integrations.DeleteOne(b => b.IntegrationName == integrationName);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }
        //public bool RemoveBoardById(int boardId)
        //{
        //    var deletedResult = contextObj.Boards.DeleteOne(b => b.BoardId == boardId);
        //    return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        //}


        public bool UpdateIntegration(string integrationUrl, EIntegration integration)
        {
            var filter = Builders<EIntegration>.Filter.Where(i => i.IntegrationUrl == integrationUrl);
            var updateResult = context.Integrations.ReplaceOne(filter, integration);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
