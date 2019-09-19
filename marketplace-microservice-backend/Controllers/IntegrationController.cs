using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using marketplace_microservice_backend.BussinessLayer;
using marketplace_microservice_backend.BussinessLayer.Exception;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace marketplace_microservice_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly IIntegrationService service;
        public IntegrationController(IIntegrationService integrationService)
        {
            service = integrationService;
        }
        
        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(service.GetIntegrationByName(name));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
        [HttpPost]
        public IActionResult Post([FromBody] EIntegration Integration)
        {
            try
            {
                service.CreateIntegration(Integration);
                return StatusCode((int)HttpStatusCode.Created, Integration);
            }
            catch (IntegrationAlreadyExistsException nex)
            {
                return Conflict(nex.Message);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpPut("{integrationUrl}")]
        public IActionResult Put(string integrationUrl, [FromBody] EIntegration Integration)
        {
            try
            {
                service.UpdateIntegration(integrationUrl, Integration);
                return StatusCode((int)HttpStatusCode.Created, Integration);
            }
            catch (IntegrationNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllIntegrations()
        {
            try
            {
                return Ok(service.GetAllIntegrations());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpDelete]
        [Route("{name}")]
        public IActionResult DeleteIntegrationByName(string name)
        {
            try
            {
                service.RemoveIntegrationByName(name);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}