using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class Issues
    {    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string userName { get; set; }
        public string[] labelNames { get; set; }
    }

    public class User
    {
        [BsonElement("uname")]
        public string UName { get; set; }
        [BsonElement("utoken")]
        public string UToken { get; set; }
        [BsonElement("urepository")]
        public string Urepository { get; set; }
    }
    public class MyGitHub
    {
        public List<MyGitHub> myGitHubs { get; set; }
    }

}
