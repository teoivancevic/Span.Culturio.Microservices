using System;
namespace Span.Culturio.Microservices.Packages.Models
{
    public class PackageDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int ValidDays { get; set; }

        public virtual ICollection<PackageCultureObjectDto> CultureObjects { get; set; }


    }
}

