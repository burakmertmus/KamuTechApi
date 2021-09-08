using AutoMapper;
using KamuTechApi.Models;
using KamuTechApi.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamuTechApi.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Comments, GetCommentsModel>()
                .ForMember(dest => dest.ComponentId, opt =>
            {
                opt.MapFrom(src => src.Photo.Id);
            }).ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photo.IdNavigation.Url);
            });
                
            CreateMap<GetCommentsModel, Comments>();


            CreateMap<Cards, GetCardsModel>()
                .ForMember(dest => dest.ComponentId, opt =>
            {
                opt.MapFrom(src => src.Photo.Id);
            }).ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photo.IdNavigation.Url);
            }); ;

            CreateMap<GetCardsModel, Cards>();
            


        }
    }
}
