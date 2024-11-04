using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IPostRepository
    {
        IEnumerable<PostDto> GetAllPosts(bool trackChanges);
        PostDto GetPost(int id, bool trackChanges);
    }
}
