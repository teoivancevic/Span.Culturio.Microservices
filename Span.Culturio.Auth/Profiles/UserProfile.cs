using System;
using AutoMapper;
using Span.Culturio.Auth.Data.Entities;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Auth.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            //CreateMap<UserDto, RegisterUserDto>();
            CreateMap<RegisterUserDto, UserDto>(); //iz registeruserdto u userdto

            //CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();
        }
    }
}

