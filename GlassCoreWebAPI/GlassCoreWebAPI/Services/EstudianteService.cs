using AutoMapper;
using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.EstudianteDTOs;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace GlassCoreWebAPI.Services
{
    public class EstudianteService
    {
        private readonly IRepository<Estudiante> _repository;
        private readonly IRepository<Usuario> _usuarioRepository;

        private readonly IMapper _mapper;
        private readonly GlassCoreContext _glassCoreContext;
        private readonly IUsuarioRepository _Repository;
        private readonly IRepository<Carrera> _carreraRepository;

        public EstudianteService(IRepository<Estudiante> repository, IRepository<Usuario> usuarioRepository, GlassCoreContext glassCoreContext, IMapper mapper ,IRepository<Carrera> carreraRepository)
        {
            _usuarioRepository = usuarioRepository;
            _repository = repository;
            _carreraRepository = carreraRepository;
            _mapper = mapper;
            _glassCoreContext = glassCoreContext;   
           
        }
                
        public IEnumerable<RankingDTO> ShowRanking()
        {
            var estudiantes = _repository.GetAll();

            // Cargar explícitamente las entidades relacionadas (Usuario y Carrera)
            foreach (var estudiante in estudiantes)
            {
                _glassCoreContext.Entry(estudiante)
                    .Reference(e => e.IdUsuarioNavigation)
                    .Load();

                _glassCoreContext.Entry(estudiante)
                    .Reference(e => e.IdCarreraNavigation)
                    .Load();
            }

            var rankingDTOs = estudiantes.Select(e => new RankingDTO
            {
                NombreUsuario = e.IdUsuarioNavigation.NombreUsuario,
                ApellidoUsuario = e.IdUsuarioNavigation.ApellidoUsuario,
                UserName = e.IdUsuarioNavigation.UserName,
                IndiceGeneral = e.IndiceGeneral,
                Trimestre = e.Trimestre,
                NombreCarrera = e.IdCarreraNavigation.NombreCarrera
            }).OrderByDescending(dto => dto.IndiceGeneral) // Ordenar por IndiceGeneral de mayor a menor
            .ToList();


            return rankingDTOs;

        }

        public Estudiante CreateEstudiante(CrearEstudianteDTO estudianteDTO)
        {

            var lastUser = _glassCoreContext.Usuarios.OrderByDescending(e => e.IdUsuario).FirstOrDefault()!;

            if (lastUser.Rol != "Estudiante")
            {
                return null;
            }


            Carrera CarreraBuscada = _carreraRepository.Get(c => c.NombreCarrera == estudianteDTO.NombreCarrera)!;


            Estudiante estudiante = new Estudiante { 
                IdUsuario = lastUser.IdUsuario,
                IdCarrera = CarreraBuscada.IdCarrera
            };

            _repository.Create(estudiante);
            return _repository.Get(e => e.IdUsuario == lastUser.IdUsuario)!;
        }
    }
}
