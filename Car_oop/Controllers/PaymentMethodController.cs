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
    [Route("api/PaymentMethod")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentRepository;
        private readonly IValidator<PaymentMethodForCreationDto> _postpaymentlValidator;
        private readonly IValidator<PaymentForUpdateDto> _putMethodValidator;

        public PaymentMethodController(IPaymentMethodRepository paymentRepository, IValidator<PaymentMethodForCreationDto> postpaymentlValidator,
            IValidator<PaymentForUpdateDto> putMethodValidator)
        {
            _paymentRepository = paymentRepository;
            _postpaymentlValidator = postpaymentlValidator;
            _putMethodValidator = putMethodValidator;
        }
        [HttpGet]
        public IActionResult GetAllMethods()
        {
            var models = _paymentRepository.GetAllPayments(trackChanges: false);
            return Ok(models);
        }
        [HttpGet("{id:int}", Name = "GetMethod")]
        public IActionResult GetMethod(int id)
        {
            var model = _paymentRepository.GetPayment(id, trackChanges: false);
            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateMethod([FromBody] PaymentMethodForCreationDto model)
        {
            if (model == null)
                return BadRequest("Payment is null");

            FluentValidation.Results.ValidationResult result = _postpaymentlValidator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }

            var modelReturn = _paymentRepository.CreateMethod(model);
            return Ok(modelReturn);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeleteMethod(int id)
        {
            _paymentRepository.DeleteMethod(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateMethod(int id, [FromBody] PaymentForUpdateDto payment)
        {
            if (payment == null)
            {
                return BadRequest("modelCar is null");
            }

            FluentValidation.Results.ValidationResult result = _putMethodValidator.Validate(payment);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }

            _paymentRepository.UpdateMethod(id, trackChanges: true, payment);
            return NoContent();

        }
    }
}
