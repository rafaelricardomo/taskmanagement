using FluentValidation;
using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public class CriarTarefaValidator : AbstractValidator<CriarTarefaDto>
    {
        public CriarTarefaValidator()
        {

            RuleFor(r => r.titulo).NotEmpty().NotNull().WithMessage("titulo inválido");
            RuleFor(r => r.descricao).NotEmpty().NotNull().WithMessage("descricao inválido");
            RuleFor(r => r.vencimento).GreaterThan(DateTime.Today).WithMessage("vencimento inválido");
            RuleFor(r => r.prioridade).IsInEnum().WithMessage("prioridade inválido");
        }
    }
}
