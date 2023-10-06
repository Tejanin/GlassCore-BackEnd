using AutoMapper;
using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.AreaDTOs;
using GlassCoreWebAPI.Models.CarreraDTOs;

namespace GlassCoreWebAPI.Services
{
    public class AreaService
    {

        private readonly IRepository<Area> _repository;
        private readonly IMapper _mapper;

        public AreaService(IRepository<Area> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public IEnumerable<MostrarAreaDTO> GetAll()
        {
            var areas = _repository.GetAll();
            var areasDTO = _mapper.Map<IEnumerable<MostrarAreaDTO>>(areas);
            return areasDTO;

        }
    }
}
