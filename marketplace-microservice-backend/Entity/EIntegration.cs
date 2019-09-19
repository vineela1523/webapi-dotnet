using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class EIntegration
    {
        [BsonId]
        public string UserId { get; set; }

        [BsonElement("IntegrationName")]
        public string IntegrationName { get; set; }
        [BsonElement("IntegrationDescription")]
        public string IntegrationDescription { get; set; }
        [BsonElement("IntegrationUrl")]
        public string IntegrationUrl { get; set; }
        [BsonElement("WebSiteUrl")]
        public string WebSiteUrl { get; set; }
        [BsonElement("EmailIdOfAuthour")]
        public string EmailIdOfAuthour { get; set; }
        [BsonElement("Image")]
        public string  Image { get; set; }

    }
}
