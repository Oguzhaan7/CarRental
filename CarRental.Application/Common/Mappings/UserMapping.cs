using AutoMapper;
using CarRental.Application.Users.Commands.RegisterUser;
using CarRental.Application.Users.Common;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}
