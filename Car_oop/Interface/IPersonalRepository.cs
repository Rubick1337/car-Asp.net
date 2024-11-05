using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IPersonalRepository
    {
        IEnumerable<PersonalDto> GetAllPersonal(bool trackChanges);
        PersonalDto GetPersonal(int id, bool trackChanges);
    }
}
