using AutoMapper;
using GAP.Test.Domain.Core.Contracts;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GAP.Test.Front.Application.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PolizaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool CreatePoliza(PolizaVM polizaVM)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Domain.Model.Poliza>();
                Domain.Model.Poliza poliza = _mapper.Map<Domain.Model.Poliza>(polizaVM);
                repository.Add(poliza);
                return _unitOfWork.Commit() > 0;
            }
            catch (Exception exc)
            {

                throw new Exception("The information sent is not valid.");
            }
        }

        public bool UpdatePoliza(PolizaVM polizaVM)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Domain.Model.Poliza>();
                Domain.Model.Poliza poliza = _mapper.Map<Domain.Model.Poliza>(polizaVM);
                repository.Update(poliza);
                return _unitOfWork.Commit() > 0;
            }
            catch (Exception exc)
            {

                throw new Exception("The information sent is not valid.");
            }
        }

        public async Task<bool> DeletePoliza(int idPoliza)
        {
            var repository = _unitOfWork.GetRepository<Domain.Model.Poliza>();
            var poliza =  (await repository.GetAsync(predicate: src => src.Id.Equals(idPoliza))).FirstOrDefault();
            repository.Delete(poliza);
            return _unitOfWork.Commit() > 0;
        }

        public async Task<List<PolizaVM>> GetAsync()
        {
            var repository = _unitOfWork.GetRepository<Domain.Model.Poliza>();
            var polizas = await repository.GetAsync(include: source => source.Include(src => src.Cliente).Include(src => src.TipoCubrimiento).Include(src => src.TipoRiesgo));
            return _mapper.Map<List<PolizaVM>>(polizas);
        }
    }
}
