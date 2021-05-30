using Entools.Model;
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
    public class PartOperationsController : ControllerBase
    {
        IPartOperations _service;
        public PartOperationsController(IPartOperations service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PartOperationsVM>> Get(int id)
        {
            return _service.Get(id);
        }
    }
}
