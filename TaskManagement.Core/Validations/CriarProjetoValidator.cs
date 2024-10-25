using FluentValidation;
using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public class CriarProjetoValidator : AbstractValidator<CriarProjetoDto>
    {
        public CriarProjetoValidator()
        {

            RuleFor(r => r.nome).NotEmpty().NotNull().WithMessage("Nome inválido");
        }
    }
}
