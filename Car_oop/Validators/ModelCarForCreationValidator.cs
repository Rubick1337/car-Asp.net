using FluentValidation;
using Car_oop.DTO;

namespace Car_oop.Validators
{
    public class ModelCarCreationValidator : AbstractValidator<ModelCarCreationDto>
    {
        public ModelCarCreationValidator()
        {
            RuleFor(car => car.bodyType)
                .NotEmpty().WithMessage("Тип кузова обязателен для заполнения.")
                .MaximumLength(50).WithMessage("Тип кузова не должен превышать 50 символов.");

            RuleFor(car => car.brand)
                .NotEmpty().WithMessage("Бренд обязателен для заполнения.")
                .MaximumLength(50).WithMessage("Бренд не должен превышать 50 символов.");

            RuleFor(car => car.color)
                .NotEmpty().WithMessage("Цвет обязателен для заполнения.")
                .MaximumLength(30).WithMessage("Цвет не должен превышать 30 символов.");

            RuleFor(car => car.count)
                .GreaterThanOrEqualTo(1).WithMessage("Количество должно быть не менее 1.");

            RuleFor(car => car.driveType)
                .NotEmpty().WithMessage("Тип привода обязателен для заполнения.")
                .MaximumLength(30).WithMessage("Тип привода не должен превышать 30 символов.");

            RuleFor(car => car.firm)
                .NotEmpty().WithMessage("Фирма обязателена для заполнения.")
                .MaximumLength(50).WithMessage("Фирма не должна превышать 50 символов.");

            RuleFor(car => car.fuelType)
                .NotEmpty().WithMessage("Тип топлива обязателен для заполнения.")
                .MaximumLength(30).WithMessage("Тип топлива не должен превышать 30 символов.");

            RuleFor(car => car.model)
                .NotEmpty().WithMessage("Модель обязательна для заполнения.")
                .MaximumLength(50).WithMessage("Модель не должна превышать 50 символов.");

            RuleFor(car => car.price)
                .GreaterThan(0).WithMessage("Цена должна быть положительным числом.");

            RuleFor(car => car.transmissionType)
                .NotEmpty().WithMessage("Тип трансмиссии обязателен для заполнения.")
                .MaximumLength(30).WithMessage("Тип трансмиссии не должен превышать 30 символов.");

            RuleFor(car => car.yearRealse)
                .InclusiveBetween(1886, DateTime.Now.Year).WithMessage($"Год выпуска должен быть в диапазоне от 1886 до {DateTime.Now.Year}.");
        }
    }
}
