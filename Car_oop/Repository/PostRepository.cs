using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;

namespace Car_oop.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<PostDto> GetAllPosts(bool trackChanges)
        {
            var posts = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var postsDto = posts.Select(x => new PostDto(x.Id, x.namePost)).ToList();
            return postsDto;
        }

        public PostDto GetPost(int id, bool trackChanges)
        {
            var post = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var postDto = new PostDto(post.Id, post.namePost);
            return postDto;
        }
    }
}
