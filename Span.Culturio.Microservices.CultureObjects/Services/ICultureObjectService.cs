using System;
using Span.Culturio.Microservices.CultureObjects.Models;

namespace Span.Culturio.Microservices.CultureObjects.Services
{
    public interface ICultureObjectService
    {
        Task<IEnumerable<CultureObjectDto>> GetCultureObjects();
        Task<CultureObjectDto> GetCultureObject(int id);

        Task<CultureObjectDto> CreateCultureObject(CreateCultureObjectDto cultureObject);
    }
}

