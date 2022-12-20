using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Microservices.Users.Data;
using Span.Culturio.Microservices.Users.Helpers;
using Span.Culturio.Microservices.Users.Models;

namespace Span.Culturio.Microservices.Users.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;



        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            /*
            var user = new Data.Entities.User()
            {
                Id = 1,
                FirstName = "teo",
                LastName = "ivanc",
                Email = "t@t",
                Username = "tivanc"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            */

            var users = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);


            return usersDto;
        }

        public async Task<UserDto> GetUser(int id)
        {
            //var user = _context.Users.Where(x => x.Id.Equals(id));
            var user = await _context.Users.FindAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }


    }
}

