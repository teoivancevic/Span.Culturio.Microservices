using System;
using AutoMapper;
using Span.Culturio.Microservices.CultureObjects.Data.Entities;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Microservices.CultureObjects.Profiles
{
    public class CultureObjectProfile : Profile
    {
        public CultureObjectProfile()
        {
            CreateMap<CultureObject, CultureObjectDto>();
            CreateMap<CultureObjectDto, CultureObject>();

            CreateMap<CreateCultureObjectDto, CultureObjectDto>();

            CreateMap<CreateCultureObjectDto, CultureObject>();


            //CreateMap<PackageCultureObject, PackageCultureObjectDto>();
            //CreateMap<PackageCultureObjectDto, PackageCultureObject>();
        }
    }
}

