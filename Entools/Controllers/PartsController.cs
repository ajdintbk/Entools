using Entools.Model;
using Entools.Model.Requests.Parts;
using Entools.Model.ViewModels;
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
    public class PartsController : ControllerBase
    {
        IParts _service;
        public PartsController(IParts service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Parts>> Get([FromQuery] PartSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("preview/{id}")]
        public ActionResult<List<PartVersionsVM>> GetPreview(int id)
        {
            return _service.GetPreview(id);
        }

        [HttpGet("{id}")]
        public ActionResult<Parts> GetById(int id)
        {
            var part = _service.GetById(id);
            if (part != null)
                return part;
            return NotFound("Part does not exist");
        }

        [HttpPost]
        public ActionResult<Parts> Insert(PartInsertUpdateRequest req)
        {
            var part = _service.Insert(req);
            if (part != null)
                return part;

            return BadRequest("Part already exists.");
        }

        [HttpPut("{id}")]
        public ActionResult<Parts> Update(int id, PartInsertUpdateRequest request)
        {
            var updatetPart = _service.Update(id, request);
            if (updatetPart == null)
                return BadRequest("Part does not exist.");
            return updatetPart;
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            var partId = _service.Delete(id);
            if (partId == 0)
                return BadRequest("Part does not exist.");
            return partId;
        }
    }
}
