using FluentValidation;
using System;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Application.Validations
{
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleFor(u => u.Name)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.LastName)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .EmailAddress()
                    .WithMessage("Endereço de email inválido");
            
            RuleFor(u => u.BirthDate)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .LessThan(p => DateTime.Now.AddYears(-10))
                    .WithMessage("Cadastro permitido apenas para pessoas acima de 10 anos");

        }
    }
}
