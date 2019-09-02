﻿using AutoMapper;
using GAP.Test.Front.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure.Helper
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor of mapping profile
        /// </summary>
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Domain.Model.Poliza, PolizaVM>()
                .ForMember(dest => dest.Nombre, act => act.MapFrom(src => $"{src.Cliente.Nombre} {src.Cliente.Apellido}"));
            CreateMap<PolizaVM, Domain.Model.Poliza>();
        }
    }
}
