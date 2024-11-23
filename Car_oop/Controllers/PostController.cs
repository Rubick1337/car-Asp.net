using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public IActionResult GetPosts()
        {
            var clients = _postRepository.GetAllPosts(trackChanges: false);
            return Ok(clients);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPost(int id)
        {
            var clients = _postRepository.GetPost(id, trackChanges: false);
            return Ok(clients);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeletePost(int id)
        {
            _postRepository.DeletePost(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public NoContentResult UpdatePost(int id,[FromBody]PostForUpdateDto post)
        {
            if(post == null)
            {
                BadRequest("Post is null");
            }
            _postRepository.UpdatePost(id, post, trackChanges: true);
            return NoContent();
        }
    }
}
