using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.Entity;
using RestSharp;

namespace marketplace_microservice_backend.BussinessLayer
{
    public class IssueService : IIssueservice
    {
        private readonly IIssueRepository Repository;
        public IssueService(IIssueRepository issueRepository)
        {
            Repository = issueRepository;
        }

        public Issues GetAllIssues(Issues issues)
        {
            return Repository.GetAllIssues(issues);
        }

        public Issues GetIssuesById(string id)
        {
            return Repository.GetIssuesById(id);
        }

        public User RegisterGitHub(User user)
        {
            var result = Repository.RegisterHub(user);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            };
        }


    }
}
