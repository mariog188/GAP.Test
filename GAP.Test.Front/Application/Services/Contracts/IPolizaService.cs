using GAP.Test.Front.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.Services.Contracts
{
    public interface IPolizaService
    {
        bool CreatePoliza(PolizaVM polizaVM);

        Task<List<PolizaVM>> GetAsync();
    }    
}
