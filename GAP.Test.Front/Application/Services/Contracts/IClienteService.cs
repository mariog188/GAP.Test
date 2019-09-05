using GAP.Test.Front.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.Services.Contracts
{
    public interface IClienteService
    {
        Task<List<ClienteVM>> GetAsync();
    }
}
