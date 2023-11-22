using AutoMapper;
using DemoDAL.Models;
using DemoEL.ViewsModels;

namespace DemoEL.ProfilesMaping
{
    public class DepurtmentProfaile: Profile
    {
        public DepurtmentProfaile()
        { 
            CreateMap<Depurtment , DepurtmentViewModelcs>().ReverseMap();
        }
    }
}
