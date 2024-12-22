using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
public class ClientForCreationValidator : AbstractValidator<ClientForCreationcs>
{
    public ClientForCreationValidator()
    {
        RuleFor(client => client.clientPhone)
            .NotEmpty().WithMessage("Номер телефона обязателен для заполнения.")
            .Matches(@"^\+375\s?\(?\d{2}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$")
            .WithMessage("Неверный формат номера телефона. Номер должен быть в формате +375XX XXX-XX-XX.");
        
        RuleFor(client => client.name)
            .NotEmpty().WithMessage("Имя обязательно для заполнения.")
            .Length(2, 50).WithMessage("Имя должно быть от 2 до 50 символов.");

        RuleFor(client => client.email)
            .NotEmpty().WithMessage("Email обязателен для заполнения.")
            .EmailAddress().WithMessage("Неверный формат email.");

        RuleFor(client => client.passport)
            .NotEmpty().WithMessage("Номер паспорта обязателен для заполнения.");

        RuleFor(client => client.surname)
            .NotEmpty().WithMessage("Фамилия обязательна для заполнения.")
            .Length(2, 50).WithMessage("Фамилия должна быть от 2 до 50 символов.");
    }
}

}
