using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Test.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService _polizaService;

        public PolizaController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpPost()]
        [Produces("application/json")]
        public async Task<IActionResult> CreatePoliza(PolizaVM poliza)
        {
            return _polizaService.CreatePoliza(poliza) ?
                    Created("/Poliza", "Poliza was created") :
                    StatusCode((int)HttpStatusCode.InternalServerError, "Internal error during poliza creation");
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<List<PolizaVM>> GetAsync()
        {
            return await _polizaService.GetAsync();
        }
    }
}