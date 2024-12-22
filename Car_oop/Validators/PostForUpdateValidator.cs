﻿using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
    public class PostForUpdateValidator : AbstractValidator<PostForUpdateDto>
    {
        public PostForUpdateValidator() {
            RuleFor(post => post.namePost)
             .NotEmpty().WithMessage("Название должности обязательно для заполнения.")
             .Length(2, 100).WithMessage("Название должности должно быть от 2 до 100 символов.");
        }
    }
}
