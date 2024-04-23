using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve ter no mínimo 6 caracteres");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(30)
                .WithMessage("Nome deve ter entre 5 e 30 caracteres");

            RuleFor(u => u.BirthDate)
                .LessThan(DateTime.Now)
                .WithMessage("Data de nascimento inválida");
        }

        private bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }
    }
}
