using marketplace_microservice_backend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.BussinessLayer
{
    public interface IIssueservice
    {
        Issues GetIssuesById(string id);
        Issues GetAllIssues(Issues issues);
        User RegisterGitHub(User user);

    }
}
