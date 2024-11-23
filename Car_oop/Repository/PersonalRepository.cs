using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;

namespace Car_oop.Repository
{
    public class PersonalRepository : RepositoryBase<Person>, IPersonalRepository
    {
        private readonly IMapper _mapper;
        public PersonalRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<PersonalDto> GetAllPersonal(bool trackChanges)
        {
            var persons = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var perosonsDto = persons.Select(x => new PersonalDto(x.Id, string.Join(' ', x.name, x.surname), x.payday, x.experience, x.PostId)).ToList();
            var perosonsDto = _mapper.Map<IEnumerable<PersonalDto>>(persons);
            return perosonsDto;
        }

        public PersonalDto GetPersonal(int id, bool trackChanges)
        {
            var persons = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            //var perosonsDto = new PersonalDto(persons.Id, string.Join(' ', persons.name, persons.surname), persons.payday, persons.experience, persons.PostId);
            var perosonsDto = _mapper.Map<PersonalDto>(persons);
            return perosonsDto;
        }
        public PersonalDto CreatePersonal(PersonalForCreationDto personal, int PostId, bool trackChanges)
        {
            var postCheck = _context.Set<Post>()
                .Where(x => x.Id.Equals(PostId))
                .AsNoTracking()
                .SingleOrDefault();
            var personalEntity = _mapper.Map<Person>(personal);
            personalEntity.PostId = PostId;
            Create(personalEntity);
            var personalReturn = _mapper.Map<PersonalDto>(personalEntity);
            return personalReturn;
        }
        public void DeletePersonal (int Id, bool trackChanges)
        {
            var personalCheck = _context.Set<Person>()
                .Where(x => x.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefault();
            if (personalCheck == null)
            {
                throw new NotFound();
            }

            Delete(personalCheck);
            _context.SaveChanges();
        }
    }
}
