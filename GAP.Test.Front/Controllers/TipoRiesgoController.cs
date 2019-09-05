using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Test.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRiesgoController : ControllerBase
    {
        private readonly ITipoRiesgoService _tipoRiesgoService;

        public TipoRiesgoController(ITipoRiesgoService tipoRiesgoService)
        {
            _tipoRiesgoService = tipoRiesgoService;
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<List<TipoRiesgoVM>> GetAsync()
        {
            return await _tipoRiesgoService.GetAsync();
        }
    }
}