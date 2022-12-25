using System;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Auth.Services
{
	public interface IAuthService
    {
        //ne bih smio zapravo imati ovu metodu u Auth, ali nemam vremena spojiti kako treba pa radim ovako
        Task<UserDto> GetUserByUsername(string username);


        Task<UserDto> CreateUser(RegisterUserDto user);
        Task<bool> Login(UserDto user, string password);

    }
}

