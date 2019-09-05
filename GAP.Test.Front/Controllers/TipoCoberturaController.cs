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
    public class TipoCoberturaController : ControllerBase
    {
        private readonly ITipoCoberturaService _tipoCoberturaService;
        public TipoCoberturaController(ITipoCoberturaService tipoCoberturaService)
        {
            _tipoCoberturaService = tipoCoberturaService;
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<List<TipoCoberturaVM>> GetAsync()
        {
            return await _tipoCoberturaService.GetAsync();
        }
    }
}