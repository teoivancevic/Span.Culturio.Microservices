using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Microservices.Packages.Data;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Microservices.Packages.Services
{
    public class PackageService : IPackageService
    {


        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public PackageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<IEnumerable<PackageDto>> GetPackages()
        {

            var packages = await _context.Packages.Include(x => x.CultureObjects).ToListAsync();

            var packagesDto = _mapper.Map<List<PackageDto>>(packages);
            return packagesDto;
        }

        public async Task<PackageDto> GetPackage(int id)
        {
            var package = await _context.Packages.Include(x => x.CultureObjects).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            //package.CultureObjects = await _context.PackageCultureObjects.Where(x => x.Package.Id.Equals(package.Id)).ToListAsync();
            var packageDto = _mapper.Map<PackageDto>(package);
            return packageDto;
        }

        public async Task<int> GetPackageDays(int id)
        {
            var package = await GetPackage(id);

            return package.ValidDays;
        }

        public async Task<int> GetAvailableVisits(int cultureObjectId, int packageId)
        {
            var package = await GetPackage(packageId);

            var tmpCultureObject = package.CultureObjects.Where(x => x.CultureObjectId.Equals(cultureObjectId)).FirstOrDefault();
            int availableVisits = 0;
            if(tmpCultureObject is not null){
                availableVisits = tmpCultureObject.AvailableVisits;
            }
            

            return availableVisits;

        }



        public async Task<PackageDto> CreatePackage(CreatePackageDto package)
        {
            var packageEntity = _mapper.Map<Data.Entities.Package>(package);
            _context.Packages.Add(packageEntity);

            await _context.SaveChangesAsync();

            var packageDto = _mapper.Map<PackageDto>(packageEntity);
            return packageDto;
        }




        public async Task<PackageCultureObjectDto> CreatePackageCultureObject(CreatePackageCultureObjectDto packageCultureObject)
        {
            var packageCultureObjectEntity = _mapper.Map<Data.Entities.PackageCultureObject>(packageCultureObject);
            //packageCultureObjectEntity.Package = _context.Packages.FindAsync(packageCultureObject.PackageId);
            _context.PackageCultureObjects.Add(packageCultureObjectEntity);

            await _context.SaveChangesAsync();

            var packageCultureObjectDto = _mapper.Map<PackageCultureObjectDto>(packageCultureObjectEntity);
            return packageCultureObjectDto;
        }




    }
}

