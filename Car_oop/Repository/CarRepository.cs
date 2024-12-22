using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;

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
        public CarDto CreateCar(int carModelId, bool trackChanges)
        {
            var carEntity = new Car
            {
                ModelCarId = carModelId
            };

            Create(carEntity);

            var carDto = _mapper.Map<CarDto>(carEntity);
            return carDto;
        }
        public void DeleteCar(int Id, bool trackChanges)
        {
            var carCheck = _context.Set<Car>()
                .Where(x => x.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefault();
            if (carCheck == null)
            {
                throw new NotFound();
            }

            Delete(carCheck);
            _context.SaveChanges();
        }
        public void UpdateCar(int id, bool trackChanges, int CarModelId)
        {
            var clientEntity = FindByCondition(cl => cl.Id.Equals(id), trackChanges)
                .SingleOrDefault();

            if (clientEntity == null)
            {
                throw new NotFound();
            }

            clientEntity.ModelCarId = CarModelId;

            _context.SaveChanges();
        }


    }
}
