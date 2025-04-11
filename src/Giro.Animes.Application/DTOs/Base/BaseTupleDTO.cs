namespace Giro.Animes.Application.DTOs.Base
{
    /// <summary>
    /// Classe base para DTOs de tuplas.
    /// </summary>
    public abstract class BaseTupleDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Nome do objeto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        protected BaseTupleDTO(long id, string name) : base(id)
        {
            Name = name;
        }
    }
}
