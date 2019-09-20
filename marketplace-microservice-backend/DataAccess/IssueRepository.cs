using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.Entity;
using MongoDB.Driver;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace marketplace_microservice_backend.DataAccess
{
    public class IssueRepository:IIssueRepository
    {
        private readonly AllDbContext context;
        public IssueRepository(AllDbContext allDbContext)
        {
            context = allDbContext;
        }

        public Issues GetAllIssues(Issues issues)
        {
            //// Deserializing json data to object  
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Issues issues = js.Deserialize<Issues>(content);
            //string title = issues.IssueTitle;
            //string description = issues.IssueDescription;


            // Other way to whithout help of BlogSites class  
            //Issues issues = JsonConvert.DeserializeObject<Issues>(content);

            //var serializer = new JavaScriptSerializer();
            //dynamic jsonObject = serializer.Deserialize<dynamic>(content);

            //myProperty = Convert.MyPropertyType(jsonObject["myProperty"]);

            //var jobj = (JObject)JsonConvert.DeserializeObject(content);
            //var items = jobj.Children()
            //    .Cast<JProperty>()
            //    .Select(j => new
            //    {
            //        ID = j.Name,
            //        title = (string)j.Value["title"],
            //        body = (string)j.Value["body"],
            //        labels = (string)j.Value["labels"],
            //    })
            //    .ToList();


            context.Issues.InsertOne(issues);
            return issues;
        }

        public Issues GetIssuesById(string id)
        {
            return context.Issues.Find(i => i.id == id).SingleOrDefault();
        }

        public User RegisterHub(User user)
        {
            context.User.InsertOne(user);
            return user;
        }
        public void AddIssuesToDb(Issues issue) 
        {
            context.Issues.InsertOne(issue);
        }
    }
}
