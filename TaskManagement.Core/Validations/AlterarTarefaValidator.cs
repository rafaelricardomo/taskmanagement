using FluentValidation;
using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public class AlterarTarefaValidator : AbstractValidator<AlterarTarefaDto>
    {
        public AlterarTarefaValidator()
        {

            RuleFor(r => r.titulo).NotEmpty().NotNull().WithMessage("titulo inválido");
            RuleFor(r => r.descricao).NotEmpty().NotNull().WithMessage("descricao inválido");
            RuleFor(r => r.vencimento).GreaterThan(DateTime.Today).WithMessage("vencimento inválido");
            RuleFor(r => r.status).IsInEnum().WithMessage("status inválido");
        }
    }
}
