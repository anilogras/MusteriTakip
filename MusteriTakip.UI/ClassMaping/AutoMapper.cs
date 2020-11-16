using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using MusteriTakip.DTOs.CariDtos;
using MusteriTakip.DTOs.FisDtos;
using MusteriTakip.DTOs.KullaniciDtos;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.ClassMaping
{
    public class AutoMapper : Profile
    {



        public AutoMapper()
        {
            CreateMap<UserRoleListDto, UserRole>()
                .ForMember(dest => dest.Role, act => act.MapFrom(src => src.Rol))
                .ForMember(dest => dest.User, act => act.MapFrom(src => src.Kullanici));
            CreateMap<UserRole, UserRoleListDto>()
                .ForMember(dest => dest.Rol, act => act.MapFrom(src => src.Role))
                .ForMember(dest => dest.Kullanici, act => act.MapFrom(src => src.User));

            CreateMap<RoleListDto, Role>();
            CreateMap<Role, RoleListDto>();

            CreateMap<KullaniciListDto, User>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles));

            CreateMap<User, KullaniciListDto>()
                 .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles));



            CreateMap<Cari, CariListDto>()
                .ForMember(dest => dest.CariAdresBilgileri, act => act.MapFrom(src => src.CariAdreslers))
                .ForMember(dest => dest.CariCepTelefonlari, act => act.MapFrom(src => src.CariTelefons))
                .ForMember(dest => dest.CariEMailAdresleri, act => act.MapFrom(src => src.CariEMails))
                .ForMember(dest => dest.CariFaxTelefonlari, act => act.MapFrom(src => src.CariFaxes))
                .ForMember(dest => dest.CariSabitTelefonlari, act => act.MapFrom(src => src.CariTelefons))
                .ForMember(dest => dest.CariVDBilgileri, act => act.MapFrom(src => src.CariVd))
                .ForMember(dest => dest.CariWebSiteBilgileri, act => act.MapFrom(src => src.CariWebSites));



            CreateMap<CariListDto, Cari>()
                .ForMember(dest => dest.CariAdreslers, act => act.MapFrom(src => src.CariAdresBilgileri))
                .ForMember(dest => dest.CariCeps, act => act.MapFrom(src => src.CariSabitTelefonlari))
                .ForMember(dest => dest.CariEMails, act => act.MapFrom(src => src.CariEMailAdresleri))
                .ForMember(dest => dest.CariFaxes, act => act.MapFrom(src => src.CariFaxTelefonlari))
                .ForMember(dest => dest.CariTelefons, act => act.MapFrom(src => src.CariSabitTelefonlari))
                .ForMember(dest => dest.CariVd, act => act.MapFrom(src => src.CariVDBilgileri))
                .ForMember(dest => dest.CariWebSites, act => act.MapFrom(src => src.CariWebSiteBilgileri));

            CreateMap<FisOzellik, FisOzellikDto>();
            CreateMap<FisOzellikDto, FisOzellik>();

            CreateMap<Fis, FisDto>()
                .ForMember(dest => dest.FisOzellikleri, act => act.MapFrom(src => src.FisOzelliks))
                .ForMember(dest => dest.Kullanici, act => act.MapFrom(src => src.User));

            CreateMap<FisDto, Fis>()
                .ForMember(dest => dest.FisOzelliks, act => act.MapFrom(src => src.FisOzellikleri))
                .ForMember(dest => dest.User, act => act.MapFrom(src => src.Kullanici));

        }


    }
}
