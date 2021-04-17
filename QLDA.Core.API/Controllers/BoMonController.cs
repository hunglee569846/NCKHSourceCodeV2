using Microsoft.AspNetCore.Mvc;
using NCKH.Core.Domain.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDA.Core.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class BoMonController : ControllerBase
    {
        private readonly IBoMonService _iBoMonService;
        public BoMonController(IBoMonService iBoMonService)
        {
            _iBoMonService = iBoMonService;
        }
        [AcceptVerbs("GET"), Route("GetAll")]
        [SwaggerOperation(Summary = "SelectAll lBoMon", Description = "Requires login verification!", OperationId = "GetAllBoMon", Tags = new[] { "BoMon" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iBoMonService.SelectAllAsync();
            return Ok(result);
        }
    }

}
