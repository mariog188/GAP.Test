using AutoMapper;
using GAP.Test.Domain.Core.Contracts;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<List<ClienteVM>> GetAsync()
        {
            var repository = _unitOfWork.GetRepository<Domain.Model.Cliente>();
            var clientes = await repository.GetAsync();
            return _mapper.Map<List<ClienteVM>>(clientes);
        }
    }
}
