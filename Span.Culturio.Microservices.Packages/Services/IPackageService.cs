using System;
using Span.Culturio.Microservices.Packages.Data.Entities;
using Span.Culturio.Microservices.Packages.Models;

namespace Span.Culturio.Microservices.Packages.Services
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetPackages();
        Task<PackageDto> GetPackage(int id);

        Task<int> GetPackageDays(int id);
        Task<int> GetAvailableVisits(int cultureObjectId, int packageId);

        Task<PackageDto> CreatePackage(CreatePackageDto package);

        Task<PackageCultureObjectDto> CreatePackageCultureObject(CreatePackageCultureObjectDto packageCultureObject);



    }
}

