using Entools.Model;
using Entools.Model.Requests.Tools;
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
    public class ToolsController : ControllerBase
    {
        ITools _service;
        public ToolsController(ITools service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Tools> Insert([FromBody] ToolsInsertUpdateRequest request)
        {
            var tool = _service.Insert(request);
            if (tool == null)
                return BadRequest("Tool with that name already exists.");
            return tool;
        }

        [HttpGet]
        public ActionResult<List<Tools>> Get([FromQuery] ToolsSearchRequest request)
        {
            var tools = _service.Get(request);
            if (tools == null)
                return BadRequest("No tools with that query.");
            return tools;
        }

        [HttpPut("{id}")]
        public ActionResult<Tools> Update(int id, ToolsInsertUpdateRequest request)
        {
            var tool = _service.Update(id, request);
            if (tool == null)
                return BadRequest("Machine does not exist.");
            return tool;
        }
    }
}
