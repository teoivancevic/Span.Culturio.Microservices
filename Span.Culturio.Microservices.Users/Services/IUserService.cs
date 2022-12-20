using System;
using Span.Culturio.Microservices.Users.Models;

namespace Span.Culturio.Microservices.Users.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int id);
        Task<UserDto> GetUserByUsername(string username);


    }
}

