using FluentValidation;
using Car_oop.DTO;

namespace Car_oop.Validators
{
    public class OrderForUpdateValidator : AbstractValidator<OrderForUpdateDto>
    {
        public OrderForUpdateValidator()
        {
            RuleFor(order => order.orderDate)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Дата заказа не может быть в прошлом.")
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
