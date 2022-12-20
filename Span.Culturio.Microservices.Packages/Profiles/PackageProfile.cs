using System;
using AutoMapper;
using Span.Culturio.Microservices.Packages.Data.Entities;
using Span.Culturio.Microservices.Packages.Models;

namespace Span.Culturio.Microservices.Packages.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>();
            CreateMap<PackageDto, Package>();

            CreateMap<CreatePackageDto, Package>();
            CreateMap<Package, CreatePackageDto>();



        }
    }
}

