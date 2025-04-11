namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class BaseDTO : BaseSimpleDTO
    {
        public DateTime CreationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        protected BaseDTO(long? id, DateTime creationDate, DateTime updateDate) : base(id)
        {
            CreationDate = creationDate;
            UpdateDate = updateDate;
        }
    }
}
