using FluentValidation;
using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public class AlterarProjetoValidator : AbstractValidator<AlterarProjetoDto>
    {
        public AlterarProjetoValidator()
        {

            RuleFor(r => r.nome).NotEmpty().NotNull().WithMessage("Nome inválido");
        }
    }
}
