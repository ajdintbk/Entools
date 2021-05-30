using Entools.Model;
using Entools.Model.Requests.Versions;
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
    public class VersionController : ControllerBase
    {
        IVersions _service;
        public VersionController(IVersions service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public ActionResult<Versions> GetById(int id)
        {
            var version = _service.GetById(id);
            if (version != null)
                return version;
            return NotFound("Version does not exist");
        }

        [HttpPost]
        public ActionResult<Versions> Insert(VersionInsertUpdateRequest req)
        {
            var version = _service.Insert(req);
            if (version != null)
                return version;

            return BadRequest("Version already exists.");
        }

        [HttpPut("{id}")]
        public ActionResult<Versions> Update(int id, VersionInsertUpdateRequest request)
        {
            var version = _service.Update(id, request);
            if (version == null)
                return BadRequest("Version does not exist or gcode path is not provided.");
            return version;
        }
    }
}
