using FluentValidation;
using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public class CriarComentarioValidator : AbstractValidator<CriarComentarioDto>
    {
        public CriarComentarioValidator()
        {

            RuleFor(r => r.descricao).NotEmpty().NotNull().WithMessage("descrição inválido");
        }
    }
}
