namespace Giro.Animes.Domain.ValueObjects
{
    public record EntityResult<TEntity>
    {
        public TEntity Entity { get; private set; }
        public IEnumerable<Notification> Errors { get; private set; } = new List<Notification>();
        public bool IsValid => !Errors.Any();

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="entity"></param>
        public EntityResult(TEntity entity, IEnumerable<Notification> errors)
        {
            Entity = entity;
            Errors = errors;
        }

        /// <summary>
        /// Cria uma instância de EntityResult. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static EntityResult<TEntity> Create(TEntity entity, IEnumerable<Notification> errors)
        {
            return new EntityResult<TEntity>(entity, errors);
        }
    }
}
