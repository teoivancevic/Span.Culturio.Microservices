using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Auth.Data;
using Span.Culturio.Auth.Helpers;
using Span.Culturio.Auth.Models;

namespace Span.Culturio.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;



        public AuthService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        //ovo bi trebalo obrisat i napravit da se poziva api od Users mikroservisa
        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        //dolje je dio za auth controller
        public async Task<UserDto> CreateUser(RegisterUserDto registeredUser)
        {
            var user = _mapper.Map<UserDto>(registeredUser);
            user.Id = 0;
            var userEntity = _mapper.Map<Data.Entities.User>(registeredUser);
            UserHelper.CreatePasswordHash(registeredUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            //u FairBank tu ima Account dio, msm da mi to ne treba nista

            //var user = _mapper.Map<UserDto>(userEntity);
            return user;
        }


        public async Task<bool> Login(UserDto user, string password)
        {
            var userEntity = await _context.Users.FindAsync(user.Id);
            if (userEntity is not null && UserHelper.VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return true;
            }

            return false;
        }

    }
}

