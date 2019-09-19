using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.Entity
{
    public class Issues
    {

      
        public string id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
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
