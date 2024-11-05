using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface ICarRepository
    {
        IEnumerable<CarDto> GetAllCars(bool trackChanges);
        CarDto GetCar(int id, bool trackChanges);
    }
}
