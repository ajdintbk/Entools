using Entools.Model;
using Entools.Model.Requests.VersionRequest;
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
    public class VersionRequestController : ControllerBase
    {
        IVersionRequest _service;
        public VersionRequestController(IVersionRequest service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<VersionRequest>> Get([FromQuery] int id)
        {
            var vr = _service.Get(id);
            if (vr != null)
                return vr;
            return NotFound("Does not exist");
        }
        [HttpPost]
        public ActionResult<VersionRequest> Insert(VersionRequestInsertUpdateRequest req)
        {
            var versionRequest = _service.Insert(req);

            return Ok(versionRequest);
        }
    }
}
