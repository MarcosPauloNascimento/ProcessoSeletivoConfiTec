using FluentValidation;
using System;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Application.Validations
{
    public class UserValidations : AbstractValidator<Usuario>
    {
        public UserValidations()
        {
            RuleFor(u => u.Nome)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Sobrenome)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .EmailAddress()
                    .WithMessage("Endereço de email inválido");
            
            RuleFor(u => u.DataNascimento)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .LessThan(p => DateTime.Now)
                    .WithMessage("A data de nascimento não pode ser maior do que hoje");

        }
    }
}
