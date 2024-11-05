using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;

namespace Car_oop.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<CarDto> GetAllCars(bool trackChanges)
        {
            var cars = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var carsDto = cars.Select(x => new CarDto(x.Id, x.ModelCarId)).ToList();
            return carsDto;
        }

        public CarDto GetCar(int id, bool trackChanges)
        {
            var cars = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var carsDto = new CarDto(cars.Id, cars.ModelCarId);
            return carsDto;
        }
    }
}
