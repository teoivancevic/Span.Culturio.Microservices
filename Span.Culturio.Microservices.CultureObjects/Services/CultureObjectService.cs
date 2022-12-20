using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Microservices.CultureObjects.Data;
using Span.Culturio.Microservices.CultureObjects.Models;

namespace Span.Culturio.Microservices.CultureObjects.Services
{
    public class CultureObjectService : ICultureObjectService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public CultureObjectService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CultureObjectDto>> GetCultureObjects()
        {
            var cultureObjects = await _context.CultureObjects.ToListAsync();
            var cultureObjectsDto = _mapper.Map<List<CultureObjectDto>>(cultureObjects);
            return cultureObjectsDto;
        }

        public async Task<CultureObjectDto> GetCultureObject(int id)
        {
            var cultureObject = await _context.CultureObjects.FindAsync(id);
            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);
            return cultureObjectDto;
        }



        public async Task<CultureObjectDto> CreateCultureObject(CreateCultureObjectDto cultureObject)
        {
            //var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);
            //cultureObjectDto.Id = 0;
            var cultureObjectEntity = _mapper.Map<Data.Entities.CultureObject>(cultureObject);
            //cultureObjectEntity.Id = 0;
            _context.CultureObjects.Add(cultureObjectEntity);
            await _context.SaveChangesAsync();

            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObjectEntity);
            return cultureObjectDto;
        }
    }
}

