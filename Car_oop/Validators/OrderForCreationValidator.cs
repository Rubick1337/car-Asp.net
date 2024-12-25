using FluentValidation;
using Car_oop.DTO;

namespace Car_oop.Validators
{
    public class OrderForCreationValidator : AbstractValidator<OrderForCreationDto>
    {
        public OrderForCreationValidator()
        {
            RuleFor(order => order.orderDate)
                .GreaterThanOrEqualTo(new DateTime(2024, 1, 1))
                .WithMessage("Дата заказа не может быть раньше 2024 года.");


            RuleFor(order => order.price)
                .GreaterThan(0)
                .WithMessage("Цена должна быть больше 0.");

            RuleFor(order => order.status)
                .NotEmpty()
                .WithMessage("Статус обязателен для заполнения.")
                .Must(status => new[] { "Pending", "Completed", "Canceled" }.Contains(status))
                .WithMessage("Недопустимое значение статуса. Разрешённые значения: Pending, Completed, Canceled.");
        }
    }
}
