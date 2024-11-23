using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IModelCarRepository
    {
        IEnumerable<ModelDto> GetAllModels(bool trackChanges);
        ModelDto GetModel(int id, bool trackChanges);
        ModelDto CreateModelCar(ModelCarCreationDto model);
        void DeleteModelCar(int id,bool trackChanges);
        void UpdateModelCar(int id, ModelCarForUpdateDto modelCar, bool trackChanges);
    }
}
