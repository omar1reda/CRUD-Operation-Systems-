using AutoMapper;
using DemoDAL.Models;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Identity;

namespace DemoEL.ProfilesMaping
{
    public class UserProfaile: Profile
    {
        public UserProfaile()
        {
            CreateMap< ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}
