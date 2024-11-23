using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Car_oop.Repository
{

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private readonly IMapper _mapper;
        public PostRepository(RepositoryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<PostDto> GetAllPosts(bool trackChanges)
        {
            var posts = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var postsDto = posts.Select(x => new PostDto(x.Id, x.namePost)).ToList();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return postsDto;
        }

        public PostDto GetPost(int id, bool trackChanges)
        {
            var post = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            //var postDto = new PostDto(post.Id, post.namePost);
            var postDto = _mapper.Map<PostDto>(post);
            return postDto;
        }
        public void DeletePost(int id, bool trackChanges)
        {
            var postCheck = _context.Set<Post>()
                .Where(x => x.Id.Equals(id))
                .AsNoTracking()
                .SingleOrDefault();
            if (postCheck is null)
            {
                throw new NotFound();
            }
            Delete(postCheck);
            _context.SaveChanges();
        }
        public void UpdatePost(int id, PostForUpdateDto post, bool trackChanges)
        {
            var postCheck = FindByCondition(pt => pt.Id.Equals(id), trackChanges);
            if (postCheck is null)
            { throw new NotFound(); }
            _mapper.Map(post, postCheck);
            _context.SaveChanges();
        }
    }
}
