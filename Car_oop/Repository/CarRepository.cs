using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;

namespace Car_oop.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        private IMapper _mapper;
        public CarRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<CarDto> GetAllCars(bool trackChanges)
        {
            var cars = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var carsDto = cars.Select(x => new CarDto(x.Id, x.ModelCarId)).ToList();
            var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            return carsDto;
        }

        public CarDto GetCar(int id, bool trackChanges)
        {
            var cars = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
            if (cars == null)
            {
                throw new NotFound();
            }
            //var carsDto = new CarDto(cars.Id, cars.ModelCarId);
            var carsDto = _mapper.Map<CarDto>(cars);
            return carsDto;
        }
    }
}
