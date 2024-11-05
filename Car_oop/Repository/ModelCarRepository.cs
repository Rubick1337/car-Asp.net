using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using System.Linq;

namespace Car_oop.Repository
{
    public class ModelCarRepository : RepositoryBase<ModelCar>, IModelCarRepository
    {
        public ModelCarRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<ModelDto> GetAllModels(bool trackChanges)
        {
            var models = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var modelsDto = models.Select(x => new ModelDto(x.Id, string.Join(' ', x.model, x.color,x.firm,x.brand), x.yearRealse, string.Join(' ', x.bodyType, x.driveType, x.fuelType, x.transmissionType), x.count,x.price)).ToList();
            return modelsDto;
        }

        public ModelDto GetModel(int id, bool trackChanges)
        {
            var models = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var modelsDto =  new ModelDto(models.Id, string.Join(' ', models.model, models.color, models.firm, models.brand), models.yearRealse, string.Join(' ', models.bodyType, models.driveType, models.fuelType, models.transmissionType), models.count,models.price);
            return modelsDto;
        }
    }
}
