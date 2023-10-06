using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.ProfesorDTOs;

namespace GlassCoreWebAPI.Services
{
    public class ProfesorService
    {
        private readonly IRepository<Profesor> _repository;
        private readonly GlassCoreContext _glassCoreContext;
        private readonly IRepository<Area> _areaRepository;

        public ProfesorService(IRepository<Profesor> repository, IRepository<Area> areaRepository)
        {
            _areaRepository = areaRepository;

        }
        public Profesor CreateProfesor(CrearProfesorDTO profesorDTO)
        {
            var lastUser = _glassCoreContext.Usuarios.OrderByDescending(e => e.IdUsuario).FirstOrDefault()!;


            if(lastUser.Rol != "Profesor")
            {
                return null;
            }

            Area AreaBuscada = _areaRepository.Get(c => c.NombreArea == profesorDTO.NombreArea)!;


            Profesor profesor = new Profesor
            {
                IdUsuario = lastUser.IdUsuario,
                IdArea = AreaBuscada.IdArea
            };

            _repository.Create(profesor);
            return _repository.Get(e => e.IdUsuario == lastUser.IdUsuario)!;
        }
    }
}
