using AutoMapper;
using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.CarreraDTOs;

namespace GlassCoreWebAPI.Services
{
    public class CarreraService
    {
        private readonly IRepository<Carrera> _repository;
        private readonly IMapper _mapper;

        public CarreraService(IRepository<Carrera> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public IEnumerable<MostrarCarreraDTO> GetAll()
        {
            var carreras = _repository.GetAll();
            var carrerasDTO = _mapper.Map<IEnumerable<MostrarCarreraDTO>>(carreras);
            return carrerasDTO;

        }
    }
}
