namespace Giro.Animes.Domain.ValueObjects
{
    public record ValidationError
    {
        public string Context { get; init; }
        public string Field { get; init; }
        public string Message { get; init; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="context"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        private ValidationError(string context, string field, string message)
        {
            Context = context;
            Field = field;
            Message = message;
        }

        /// <summary>
        /// Cria uma instância de ValidationError. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="context"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ValidationError Create(string context, string field, string message) => new ValidationError(context, field, message);
    }
}
