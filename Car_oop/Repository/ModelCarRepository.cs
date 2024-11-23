﻿using AutoMapper;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Car_oop.Models.Exception_custom;
namespace Car_oop.Repository
{
    public class ModelCarRepository : RepositoryBase<ModelCar>, IModelCarRepository
    {
        private readonly IMapper _mapper;
        public ModelCarRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<ModelDto> GetAllModels(bool trackChanges)
        {
            var models = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var modelsDto = models.Select(x => new ModelDto(x.Id, string.Join(' ', x.model, x.color, x.firm, x.brand), x.yearRealse, string.Join(' ', x.bodyType, x.driveType, x.fuelType, x.transmissionType), x.count, x.price)).ToList();
            //var modelsDto = _mapper.Map<IEnumerable<ModelDto>>(models);
            return modelsDto;
        }

        public ModelDto GetModel(int id, bool trackChanges)
        {
            var models = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var modelsDto = new ModelDto(models.Id, string.Join(' ', models.model, models.color, models.firm, models.brand), models.yearRealse, string.Join(' ', models.bodyType, models.driveType, models.fuelType, models.transmissionType), models.count, models.price);
            //var modelsDto = _mapper.Map<ModelDto>(models);
            return modelsDto;
        }
        public ModelDto CreateModelCar(ModelCarCreationDto modelCar)
        {
            var modelEntity = _mapper.Map<ModelCar>(modelCar);
            Create(modelEntity);
            var modelReturn = _mapper.Map<ModelDto>(modelEntity);
            return modelReturn;
        }
        public void DeleteModelCar(int id, bool trackChanges)
        {
            var modelCarCheck = _context.Set<ModelCar>()
                .Where(x => x.Id.Equals(id))
                .AsNoTracking()
                .SingleOrDefault();
            if (modelCarCheck is null)
            {
                throw new NotFound();
            }

        }
        public void UpdateModelCar(int id,ModelCarForUpdateDto modelCar, bool trackChanges)
        {
            var modelCarFind = FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefault();
            if(modelCarFind is null)
            {
            throw new NotFound(); 
            }
            _mapper.Map(modelCar, modelCarFind);
            _context.SaveChanges();

        }
    }
}
