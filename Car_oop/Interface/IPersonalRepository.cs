using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IPersonalRepository
    {
        IEnumerable<PersonalDto> GetAllPersonal(bool trackChanges);
        PersonalDto GetPersonal(int id, bool trackChanges);

        PersonalDto CreatePersonal(PersonalForCreationDto personal, int PostId,bool trackChanges);
        void DeletePersonal(int Id,bool trackChanges);
        void UpdatePersonal(int Id,PersonalForUpdateDto personal,int? PostId,bool trackChanges);
    }
}
