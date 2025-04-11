using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class SimpleLanguageDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Language name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="SimpleLanguageDTO"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="name"></param>
        private SimpleLanguageDTO(long? id, string name) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Creates a new instance of <see cref="SimpleLanguageDTO"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SimpleLanguageDTO Create(long id, string name)
        {
            return new SimpleLanguageDTO(id, name);
        }
    }
}
