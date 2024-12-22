using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
    public class PaymentForUpdateValidator : AbstractValidator<PaymentForUpdateDto>
    {
        public PaymentForUpdateValidator()
        {
            RuleFor(payment => payment.paymentMethod)
                .NotEmpty()
                .WithMessage("Название метода оплаты обязательно для заполнения.")
                .Length(2, 100)
                .WithMessage("Название метода оплаты должно быть от 2 до 100 символов.");

        }
    }
}
