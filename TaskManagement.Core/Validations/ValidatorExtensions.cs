using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Validations
{
    public static class ValidatorExtensions
    {
        public static (bool, string[]) Validate(this CriarProjetoDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(CriarProjetoDto));

            string[] errorMessages = new string[] { };
            var validator = new CriarProjetoValidator().Validate(dto);
            if (!validator.IsValid)
                errorMessages = validator.Errors.Select(e => e.ErrorMessage).ToArray();

            return (validator.IsValid, errorMessages);
        }

        public static (bool, string[]) Validate(this CriarTarefaDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(CriarTarefaDto));

            string[] errorMessages = new string[] { };
            var validator = new CriarTarefaValidator().Validate(dto);
            if (!validator.IsValid)
                errorMessages = validator.Errors.Select(e => e.ErrorMessage).ToArray();

            return (validator.IsValid, errorMessages);
        }

        public static (bool, string[]) Validate(this AlterarTarefaDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(AlterarTarefaDto));

            string[] errorMessages = new string[] { };
            var validator = new AlterarTarefaValidator().Validate(dto);
            if (!validator.IsValid)
                errorMessages = validator.Errors.Select(e => e.ErrorMessage).ToArray();

            return (validator.IsValid, errorMessages);
        }

        public static (bool, string[]) Validate(this AlterarProjetoDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(AlterarProjetoDto));

            string[] errorMessages = new string[] { };
            var validator = new AlterarProjetoValidator().Validate(dto);
            if (!validator.IsValid)
                errorMessages = validator.Errors.Select(e => e.ErrorMessage).ToArray();

            return (validator.IsValid, errorMessages);
        }

        public static (bool, string[]) Validate(this CriarComentarioDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(CriarComentarioDto));

            string[] errorMessages = new string[] { };
            var validator = new CriarComentarioValidator().Validate(dto);
            if (!validator.IsValid)
                errorMessages = validator.Errors.Select(e => e.ErrorMessage).ToArray();

            return (validator.IsValid, errorMessages);
        }
    }
}
