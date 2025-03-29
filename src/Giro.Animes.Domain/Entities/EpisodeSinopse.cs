namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a descrição de um episódio.
    /// </summary>
    public class EpisodeSinopse : Description
    {
        /// <summary>
        /// Identificador do episódio ao qual a descrição pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o episódio da descrição.
        /// </summary>
        public Episode Episode { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public EpisodeSinopse() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="text">Texto da descrição do episódio.</param>
        /// <param name="language">Idioma da descrição.</param>
        /// <param name="episode">Episódio ao qual a descrição pertence.</param>
        private EpisodeSinopse(string text, Language language, Episode episode) : base(text, language)
        {
            Episode = episode;
        }

        /// <summary>
        /// Método estático para criar um objeto EpisodeDescription com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="text">Texto da descrição do episódio.</param>
        /// <param name="language">Idioma da descrição.</param>
        /// <param name="episode">Episódio ao qual a descrição pertence.</param>
        /// <returns>Uma nova instância de EpisodeDescription.</returns>
        public static EpisodeSinopse Create(string text, Language language, Episode episode) => new EpisodeSinopse(text, language, episode);
    }
}
