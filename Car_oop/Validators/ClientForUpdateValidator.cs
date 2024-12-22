using Car_oop.DTO;
using FluentValidation;

namespace Car_oop.Validators
{
    public class ClientForUpdateValidator : AbstractValidator<ClientForUpdateDto>
    {
        public ClientForUpdateValidator()
        {
            RuleFor(client => client.clientPhone)
                .Matches(@"^\+375\s?\(?\d{2}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$")
                .WithMessage("Неверный формат номера телефона. Номер должен быть в формате +375XX XXX-XX-XX.")
                .When(client => client.clientPhone != null);

            RuleFor(client => client.name)
                .Length(2, 50)
                .WithMessage("Имя должно быть от 2 до 50 символов.")
                .When(client => client.name != null);

            RuleFor(client => client.surname)
                .Length(2, 50)
                .WithMessage("Фамилия должна быть от 2 до 50 символов.")
                .When(client => client.surname != null);

            RuleFor(client => client.email)
                .EmailAddress()
                .WithMessage("Неверный формат email.")
                .When(client => client.email != null);

            RuleFor(client => client.passport)
                .NotEmpty()
                .WithMessage("Номер паспорта обязателен для заполнения.")
                .When(client => client.passport != null);
        }
    }
}
