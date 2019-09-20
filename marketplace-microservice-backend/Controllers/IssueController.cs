using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using marketplace_microservice_backend.BussinessLayer;
using marketplace_microservice_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Json.Net;

namespace marketplace_microservice_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueservice service;
        private string strModified;

        public IssueController(IIssueservice issueService)
        {
            service = issueService;
        }
        [HttpGet]

        public ActionResult<IEnumerable<string>> GetAllIssues(Issues issues)
        {
            try
            {
                return Ok(service.GetAllIssues(issues));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            try
            {

                return Ok(service.GetIssuesById(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                string Username = user.UName;
                string Token = user.UToken;
                string Repositatory = user.Urepository;

                byte[] byt = System.Text.Encoding.UTF8.GetBytes(Token);

                // convert the byte array to a Base64 string

                strModified = Convert.ToBase64String(byt);

                var client = new RestClient("https://api.github.com/repos");
                var request = new RestRequest($"/{Username}/{Repositatory}/issues", Method.GET);

                // Add HTTP headers
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Basic " + strModified);

                //var contributors = client.Execute<List<MyGitHub>>(request);

                IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                //var result= service.GetAllIssues(response.Content);
               

                object list = JsonConvert.DeserializeObject(response.Content);
                dynamic _d = JsonConvert.DeserializeObject(response.Content);
                Console.WriteLine(_d.Count);
                List<Issues> issuesList = new List<Issues>();
                foreach(var _dItem in _d)
                {
                    Issues _issue = new Issues();
                    _issue.body = _dItem.body;
                    _issue.title = _dItem.title;
                    _issue.userName = user.UName;
                    string[] _issueLabels = new string[_dItem.labels.Count];
                    for(int i = 0; i < _issueLabels.Length; i++)
                    {
                        _issueLabels[i] = _dItem.labels[i].name;
                    }
                    _issue.labelNames = _issueLabels;
                    issuesList.Add(_issue);
                    service.AddIssuesToDb(_issue);
                }
                Console.WriteLine(issuesList.Count);
                // AuthenticateUser(user);
                // service.RegisterGitHub(user);
                return Ok(issuesList);
            }
            catch (Exception)
            {
                return NotFound("error in converting to json");
            }

        }

        //public IRestResponse<List<User>>  AuthenticateUser(User user)
        //{
        //    var Token = user.UToken;
        //    var client = new RestClient("https://api.github.com");
        //    var request = new RestRequest("pushpendrakushwaha/MySecanarios", Method.GET);

        //    // Add HTTP headers
        //    request.AddHeader("User-Agent", "Nothing");
        //    //request.AddHeader("postman-token", "d096c034-4b88-bc0d-af5a-17a2ab474188");

        //    //request.AddHeader("cache-control", "no-cache");
        //    //request.AddHeader("authorization", "Basic " + Token);


        //    var contributors = client.Execute<List<User>>(request);
        //    return contributors;
        //}

        //internal class Contributor
        //{
        //    public string Login { get; set; }
        //    public short Contributions { get; set; }

        //    public override string ToString()
        //    {
        //        return $"{Login,20}: {Contributions} contributions";
        //    }
        //}

        //internal class Program
        //{
        //    private static void Main()
        //    {
        //        var client = new RestClient("https://api.github.com");

        //        var request = new RestRequest("repos/twilio/twilio-csharp/contributors", Method.GET);
        //        // Add HTTP headers
        //        request.AddHeader("User-Agent", "Nothing");

        //        // Execute the request and automatically deserialize the result.
        //        var contributors = client.Execute<List<Contributor>>(request);
        //        contributors.Data.ForEach(Console.WriteLine);

        //        Console.ReadLine();
        //    }
        //}
    }
}