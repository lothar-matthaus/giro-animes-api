namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class BaseSimpleDTO
    {
        public long? Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        protected BaseSimpleDTO(long? id)
        {
            Id = id;
        }
    }
}
