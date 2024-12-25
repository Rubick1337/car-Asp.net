using FluentValidation;
using Car_oop.DTO;

namespace Car_oop.Validators
{
    public class OrderForUpdateValidator : AbstractValidator<OrderForUpdateDto>
    {
        public OrderForUpdateValidator()
        {
            RuleFor(order => order.orderDate)
                .GreaterThanOrEqualTo(new DateTime(2024, 1, 1))
                .WithMessage("Дата заказа не может быть раньше 2024 года.")
                .When(order => order.orderDate.HasValue);

            RuleFor(order => order.price)
                .GreaterThan(0)
                .WithMessage("Цена должна быть больше 0.")
                .When(order => order.price.HasValue);

            RuleFor(order => order.status)
                .Must(status => new[] { "Pending", "Completed", "Canceled" }.Contains(status))
                .WithMessage("Недопустимое значение статуса. Разрешённые значения: Pending, Completed, Canceled.")
                .When(order => !string.IsNullOrWhiteSpace(order.status));
        }
    }
}
