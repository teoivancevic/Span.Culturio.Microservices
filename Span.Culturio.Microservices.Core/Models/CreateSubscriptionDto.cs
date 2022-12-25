using System;
namespace Span.Culturio.Microservices.Core.Models
{
    public class CreateSubscriptionDto
    {
        //public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
    }
}

