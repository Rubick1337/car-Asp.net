using Car_oop.Contracts;
using Car_oop.Interface;
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
    }
}
