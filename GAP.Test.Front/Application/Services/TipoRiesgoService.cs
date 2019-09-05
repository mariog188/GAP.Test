using AutoMapper;
using GAP.Test.Domain.Core.Contracts;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.Services
{
    public class TipoRiesgoService : ITipoRiesgoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TipoRiesgoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TipoRiesgoVM>> GetAsync()
        {
            var repository = _unitOfWork.GetRepository<Domain.Model.TipoRiesgo>();
            var tipos = await repository.GetAsync();
            return _mapper.Map<List<TipoRiesgoVM>>(tipos);
        }
    }
}
