using AutoMapper;
using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.AulaDTOs;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GlassCoreWebAPI.Services
{
    public class AulaService
    {
        private readonly IRepository<Aula> _repository;
        private readonly IMapper _mapper;

        public AulaService(IMapper mapper, IRepository<Aula> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        
        public IEnumerable<ShowAulaDTO> GetAll()
        {
            var aulas = _repository.GetAll();
            var aulasDTO = _mapper.Map<IEnumerable<ShowAulaDTO>>(aulas);
            return aulasDTO;

        }

        public Aula Create(CreateAulaDTO aulaDTO)
        {
            if (CheckIfExists(aulaDTO.NombreAula))
            {
                throw new InvalidOperationException("Esta aula ya existe");
            }
            var aula = _mapper.Map<Aula>(aulaDTO);
            _repository.Create(aula);
            return _repository.Get(a => a.NombreAula == aulaDTO.NombreAula)!;
        }

        public bool CheckIfExists(string aula)
        {
            return _repository.Get(a => a.NombreAula == aula) != null;
        }
    }
}
