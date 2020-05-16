using System;
using FluentValidation;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.Application.Validators
{

    public class PlanoValidator : AbstractValidator<Plano>
    {
        public PlanoValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                    });

            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("Informar o Código do Plano.")
                .NotNull().WithMessage("Informar o Código do Plano.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("Informar o Valor do Plano.")
                .NotNull().WithMessage("Informar o Valor do Plano.");

            RuleFor(c => c.Operadora)
                .NotEmpty().WithMessage("Informar a Operadora do Plano.")
                .NotNull().WithMessage("Informar o Operadora do Plano.");
        }
    }

}
