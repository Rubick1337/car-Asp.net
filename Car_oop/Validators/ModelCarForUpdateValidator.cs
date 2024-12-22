using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
    public class ModelCarForUpdateValidator : AbstractValidator<ModelCarForUpdateDto>
    {
        public ModelCarForUpdateValidator() {
            RuleFor(car => car.bodyType)
                .MaximumLength(50).WithMessage("Тип кузова не должен превышать 50 символов.")
                .When(car => car.bodyType != null);

            RuleFor(car => car.brand)
                .MaximumLength(50).WithMessage("Бренд не должен превышать 50 символов.")
                .When(car => car.brand != null);

            RuleFor(car => car.color)
                .MaximumLength(30).WithMessage("Цвет не должен превышать 30 символов.")
                .When(car => car.color != null);

            RuleFor(car => car.count)
                .GreaterThanOrEqualTo(0).WithMessage("Количество не может быть отрицательным.")
                .When(car => car.count > 0);

            RuleFor(car => car.driveType)
                .MaximumLength(30).WithMessage("Тип привода не должен превышать 30 символов.")
                .When(car => car.driveType != null);

            RuleFor(car => car.firm)
                .MaximumLength(50).WithMessage("Фирма не должна превышать 50 символов.")
                .When(car => car.firm != null);

            RuleFor(car => car.fuelType)
                .MaximumLength(30).WithMessage("Тип топлива не должен превышать 30 символов.")
                .When(car => car.fuelType != null);

            RuleFor(car => car.model)
                .MaximumLength(50).WithMessage("Модель не должна превышать 50 символов.")
                .When(car => car.model != null);

            RuleFor(car => car.price)
                .GreaterThan(0).WithMessage("Цена должна быть положительным числом.")
                .When(car => car.price > 0);

            RuleFor(car => car.transmissionType)
                .MaximumLength(30).WithMessage("Тип трансмиссии не должен превышать 30 символов.")
                .When(car => car.transmissionType != null);

            RuleFor(car => car.yearRealse)
                .InclusiveBetween(1886, DateTime.Now.Year)
                .WithMessage($"Год выпуска должен быть в диапазоне от 1886 до {DateTime.Now.Year}.")
                .When(car => car.yearRealse > 0);
        }
    }
}
