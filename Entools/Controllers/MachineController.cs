using Entools.Model;
using Entools.Model.Requests.Machines;
using Entools.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class MachineController : ControllerBase
    {
        IMachines _service;
        public MachineController(IMachines service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Machines>> Get([FromQuery] MachineSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public ActionResult<Machines> GetById(int id)
        {
            var machine = _service.GetById(id);
            if(machine != null)
                return machine;
            return NotFound("Machine does not exist");
        }

        [HttpPost]
        public ActionResult<Machines> Insert(InsertUpdateRequest req)
        {
            var machine = _service.Insert(req);
            if (machine != null)
                return machine;
            
            return BadRequest("Machine already exists.");
        }

        [HttpPut("{id}")]
        public ActionResult<Machines> Update(int id, InsertUpdateRequest request)
        {
            var updatedMachine = _service.Update(id, request);
            if (updatedMachine == null)
                return BadRequest("Machine does not exist.");
            return updatedMachine;
        }
    }
}
