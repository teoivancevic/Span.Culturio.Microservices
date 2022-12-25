using System;
namespace Span.Culturio.Microservices.Core.Models
{
    public class CreatePackageDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int ValidDays { get; set; }

        //public virtual IEnumerable<PackageCultureObjectDto> CultureObjects { get; set; }
    }
}

