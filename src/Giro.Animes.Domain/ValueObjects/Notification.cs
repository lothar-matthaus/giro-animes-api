namespace Giro.Animes.Domain.ValueObjects
{
    public record Notification
    {
        public string Context { get; init; }
        public string Property { get; init; }
        public string Message { get; init; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="context"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        private Notification(string context, string field, string message)
        {
            Context = context;
            Property = field;
            Message = message;
        }

        /// <summary>
        /// Cria uma instância de ValidationError. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="context"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Notification Create(string context, string field, string message) => new Notification(context, field, message);
    }
}
