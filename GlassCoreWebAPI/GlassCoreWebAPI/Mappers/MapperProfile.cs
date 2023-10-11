using AutoMapper;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.AreaDTOs;
using GlassCoreWebAPI.Models.CarreraDTOs;
using GlassCoreWebAPI.Models.DTOs.AulaDTOs;
using GlassCoreWebAPI.Models.DTOs.EstudianteDTOs;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;
using Microsoft.Build.Framework;

namespace GlassCoreWebAPI.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapping Configuration de los usuarios
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<Usuario, MostrarUsuarioDTO>();
            CreateMap<LoginUsuarioDTO, Usuario>();
            CreateMap<ModificarUsuarioDTO, Usuario>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));



            // Mapping Configuration de las aulas
            CreateMap<CreateAulaDTO, Aula>();
            CreateMap<Aula, ShowAulaDTO>();

            // Mapping Configuration de los estudiantes
            //CreateMap<Estudiante, RankingDTO>().ForMember(dst => dst.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation));
                 
            ;

            // Mapping Cofiguration de las carreras

            CreateMap<Carrera,MostrarCarreraDTO>();

            // Mapping Configuration de las areas

            CreateMap<Area,MostrarAreaDTO>();

        }
    }
}
