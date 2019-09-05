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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<List<ClienteVM>> GetAsync()
        {
            return await _clienteService.GetAsync();
        }
    }
}