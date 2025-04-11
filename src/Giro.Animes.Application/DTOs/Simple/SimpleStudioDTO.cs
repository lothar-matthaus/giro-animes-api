using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleStudioDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Nome do estúdio
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Construtor privado para evitar a criação de instâncias sem os parâmetros necessários. Garanta a construção pelo método Create.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private SimpleStudioDTO(long? id, string name) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleStudioDTO com os parâmetros fornecidos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SimpleStudioDTO Create(long? id, string name)
        {
            return new SimpleStudioDTO(id, name);
        }
    }
}
