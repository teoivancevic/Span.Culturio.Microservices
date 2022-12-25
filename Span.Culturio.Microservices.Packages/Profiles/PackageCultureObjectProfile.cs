using System;
using AutoMapper;
using Span.Culturio.Microservices.Packages.Data.Entities;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Microservices.Packages.Profiles
{
    public class PackageCultureObjectProfile : Profile
    {
        public PackageCultureObjectProfile()
        {
            CreateMap<CreatePackageCultureObjectDto, PackageCultureObject>();

            CreateMap<PackageCultureObjectDto, PackageCultureObject>();
            CreateMap<PackageCultureObject, PackageCultureObjectDto>();
        }

    }
}

