using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models.Exception_custom;
using Car_oop.Models;
using Car_oop.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IValidator<PostForUpdateDto> _putPostValidator;
        private readonly IValidator<PostForCreationDto> _postPostValidator;

        public PostController(IPostRepository postRepository, IValidator<PostForUpdateDto> putPostValidator,
            IValidator<PostForCreationDto> postPostValidator)
        {
            _putPostValidator = putPostValidator;
            _postRepository = postRepository;
            _postPostValidator = postPostValidator;

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
        public IActionResult UpdatePost(int id,[FromBody]PostForUpdateDto post)
        {
            if(post == null)
            {
                BadRequest("Post is null");
            }
            FluentValidation.Results.ValidationResult result = _putPostValidator.Validate(post);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }
            _postRepository.UpdatePost(id, post, trackChanges: true);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostForCreationDto post)
        {
            if (post == null)
                return BadRequest("Personal is null");

            FluentValidation.Results.ValidationResult result = _postPostValidator.Validate(post);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }
            var clientCreate = _postRepository.CreatePost(post);
            return Ok(clientCreate);
        }
    }
}
