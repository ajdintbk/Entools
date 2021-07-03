using Entools.Model;
using Entools.Model.Requests.Request;
using Entools.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        IRequests _service;
        public RequestController(IRequests service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Request>> Get([FromQuery] RequestSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpGet("{id}")]
        public ActionResult<Request> GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public ActionResult<Request> Insert(RequestInsertUpdateRequest req)
        {
            var request = _service.Insert(req);
            if (request != null)
                return request;

            return BadRequest("Machine already exists.");
        }
        [HttpPut("{id}")]
        public ActionResult<Request> Update(int id, RequestInsertUpdateRequest request)
        {
            var updatedMachine = _service.Update(id, request);
            if (updatedMachine == null)
                return BadRequest("Request does not exist.");
            return updatedMachine;
        }
    }
}
