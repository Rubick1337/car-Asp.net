using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;

namespace Car_oop.Repository
{
    public class PersonalRepository : RepositoryBase<Person>, IPersonalRepository
    {
        public PersonalRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<PersonalDto> GetAllPersonal(bool trackChanges)
        {
            var persons = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var perosonsDto = persons.Select(x => new PersonalDto(x.Id, string.Join(' ', x.name, x.surname), x.payday,x.experience,x.PostId)).ToList();
            return perosonsDto;
        }

        public PersonalDto GetPersonal(int id, bool trackChanges)
        {
            var persons = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var perosonsDto = new PersonalDto(persons.Id, string.Join(' ', persons.name, persons.surname), persons.payday, persons.experience, persons.PostId);
            return perosonsDto;
        }
    }
}
