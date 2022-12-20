using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Microservices.Packages.Models;
using Span.Culturio.Microservices.Packages.Services;

namespace Span.Culturio.Microservices.Packages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PackagesController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IPackageService _packageService;
        private readonly IConfiguration _configuration;

        public PackagesController(ILogger<PackagesController> logger, IPackageService packageService, IConfiguration configuration)
        {
            _logger = logger;
            _packageService = packageService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetPackages()
        {
            var packages = await _packageService.GetPackages();
            return Ok(packages);
        }

        /*
         * Ove tri API metode ne rade jer nisam uspio povezati tablicu PackageCultureObjects s tablicom Packages
         * 
         * Umjesto toga napravio sam seed data za Packages u PackagesService za GetPackages
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDto>> GetPackage(int id)
        {
            var package = await _packageService.GetPackage(id);
            if (package is null)
            {
                return BadRequest("Package not found.");
            }

            return Ok(package);
        }

        [HttpGet("{id}/days")]
        public async Task<ActionResult<int>> GetPackageDays(int id)
        {
            var days = await _packageService.GetPackageDays(id);
            if(days is 0)
            {
                return BadRequest("Package not found.");

            }
            
            return Ok(days);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePackage([FromBody] CreatePackageDto package)
        {
            await _packageService.CreatePackage(package);
            return Ok();
        }

        [HttpGet("available-visits/{packageId}/{cultureObjectId}")]
        public async Task<ActionResult> GetAvailableVisits(int packageId, int cultureObjectId)
        {
            var availableVisits = await _packageService.GetAvailableVisits(cultureObjectId, packageId);
            if (availableVisits is 0)
            {
                return BadRequest("Package not found.");

            }

            return Ok(availableVisits);
        }


        [HttpPost("culture-object")]
        public async Task<ActionResult> CreatePackageCultureObject([FromBody] CreatePackageCultureObjectDto packageCultureObject)
        {
            await _packageService.CreatePackageCultureObject(packageCultureObject);
            return Ok();
        }



    }
}

