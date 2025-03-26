using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class EpisodeTitle : Title
    {
        /// <summary>
        /// Identificador do episódio ao qual o título pertence
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o episódio do título
        /// </summary>
        public Episode Episode { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public EpisodeTitle() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name">Nome do título do episódio</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="episode">Episódio ao qual o título pertence</param>
        private EpisodeTitle(string name, Language language, Episode episode) : base(name, language)
        {
            Episode = episode;
        }

        /// <summary>
        /// Método estático para criar um objeto EpisodeTitle com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="name">Nome do título do episódio</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="episode">Episódio ao qual o título pertence</param>
        /// <returns>Uma nova instância de EpisodeTitle</returns>
        public static EpisodeTitle Create(string name, Language language, Episode episode) => new EpisodeTitle(name, language, episode);
    }
}
