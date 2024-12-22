using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models.Exception_custom;
using Car_oop.Models;
using Car_oop.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Car_oop.Validators;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<OrderForCreationDto> _postorderlValidator;
        private readonly IValidator<OrderForUpdateDto> _putorderValidator;

        public OrderController(IOrderRepository orderRepository, IValidator<OrderForCreationDto> postorderlValidator,
             IValidator<OrderForUpdateDto> putorderValidator)
        {
            _orderRepository = orderRepository;
            _postorderlValidator = postorderlValidator;
            _putorderValidator = putorderValidator;
        }
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var models = _orderRepository.GetAllOrders(trackChanges: false);
            return Ok(models);
        }
        [HttpGet("{id:int}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var model = _orderRepository.GetOrder(id, trackChanges: false);
            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderForCreationDto model, int ClientId,int PersonalId,int PaymentMethodId,int CarId)
        {
            if (model == null)
                return BadRequest("order is null");
            FluentValidation.Results.ValidationResult result = _postorderlValidator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }
            var personCreate = _orderRepository.CreateOrder(model, ClientId, PersonalId, PaymentMethodId, CarId, false);
            return Ok(personCreate);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderForUpdateDto order, int? ClientId, int? PersonalId, int? PaymentMethodId, int? CarId)
        {
            if (order == null)
            {
                return BadRequest("Order data is null.");
            }

            FluentValidation.Results.ValidationResult result = _putorderValidator.Validate(order);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return UnprocessableEntity(ModelState);
            }

            _orderRepository.UpdateOrder(id, order, ClientId, PersonalId, PaymentMethodId, CarId, trackChanges: true);

            return NoContent();
        }

    }
}
