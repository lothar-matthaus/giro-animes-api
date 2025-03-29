namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class BaseDTO
    {
        public long? Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public DateTime? DeletionDate { get; private set; }

        protected BaseDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate)
        {
            Id = id;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            DeletionDate = deletionDate;
        }
    }
}
