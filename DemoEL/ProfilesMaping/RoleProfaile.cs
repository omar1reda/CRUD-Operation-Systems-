using AutoMapper;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Identity;

namespace DemoEL.ProfilesMaping
{
    public class RoleProfaile: Profile
    {
        public RoleProfaile()
        {
            CreateMap<RoleViewModel , IdentityRole>().ReverseMap();
        }
    }
}
