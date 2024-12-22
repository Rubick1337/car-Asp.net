using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface ICarRepository
    {
        IEnumerable<CarDto> GetAllCars(bool trackChanges);
        CarDto GetCar(int id, bool trackChanges);
        CarDto CreateCar(int CarModelId, bool trackChanges);
        void DeleteCar(int Id, bool trackChanges);
        void UpdateCar(int id, bool trackChanges, int CarModelId);
    }
}
