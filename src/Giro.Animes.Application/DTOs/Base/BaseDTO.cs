namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class BaseDTO
    {
        public long? Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }


        protected BaseDTO()
        { }
        protected BaseDTO(long? id, DateTime creationDate, DateTime updateDate)
        {
            Id = id;
            CreationDate = creationDate;
            UpdateDate = updateDate;
        }
    }
}
