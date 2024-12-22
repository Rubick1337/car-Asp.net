﻿using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
    public class PersonalForCreationValidator : AbstractValidator<PersonalForCreationDto>
    {
        public PersonalForCreationValidator() 
        {
            RuleFor(personal => personal.experience)
               .GreaterThanOrEqualTo(0).WithMessage("Опыт не может быть отрицательным.")
               .LessThanOrEqualTo(50).WithMessage("Опыт не может превышать 50 лет.");

            RuleFor(personal => personal.name)
                .NotEmpty().WithMessage("Имя обязательно для заполнения.")
                .Length(2, 50).WithMessage("Имя должно быть от 2 до 50 символов.");

            RuleFor(personal => personal.surname)
                .NotEmpty().WithMessage("Фамилия обязательна для заполнения.")
                .Length(2, 50).WithMessage("Фамилия должна быть от 2 до 50 символов.");

            RuleFor(personal => personal.payday)
                .GreaterThan(0).WithMessage("Зарплата должна быть положительным числом.");
        }
    }
}