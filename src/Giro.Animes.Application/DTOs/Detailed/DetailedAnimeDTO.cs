﻿using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Anime.
    /// </summary>
    public class DetailedAnimeDTO : BaseDTO
    {
        /// <summary>
        /// Coleção de títulos do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Coleção de sinopses do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeSinopseDTO> Sinopses { get; private set; }

        /// <summary>
        /// Coleção de capas do anime.
        /// </summary>
        public IEnumerable<SimpleCoverDTO> Covers { get; private set; }

        /// <summary>
        /// Coleção de capturas de tela do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeScreenshotDTO> Screenshots { get; private set; }

        /// <summary>
        /// Coleção de episódios do anime.
        /// </summary>
        public IEnumerable<SimpleEpisodeDTO> Episodes { get; private set; }

        /// <summary>
        /// Coleção de autores do anime.
        /// </summary>
        public IEnumerable<SimpleAuthorDTO> Authors { get; private set; }

        /// <summary>
        /// Avaliação do anime.
        /// </summary>
        public IEnumerable<SimpleRatingDTO> Rating { get; private set; }

        /// <summary>
        /// Coleção de gêneros do anime.
        /// </summary>
        public IEnumerable<SimpleGenreDTO> Genres { get; private set; }

        /// <summary>
        /// Estúdio que criou o anime.
        /// </summary>
        public SimpleStudioDTO Studio { get; private set; }

        /// <summary>
        /// Status do anime.
        /// </summary>
        public EnumDTO<AnimeStatus> Status { get; set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="covers"></param>
        /// <param name="screenshots"></param>
        /// <param name="episodes"></param>
        /// <param name="authors"></param>
        /// <param name="rating"></param>
        /// <param name="genres"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        private DetailedAnimeDTO(
            IEnumerable<SimpleAnimeTitleDTO> titles,
            IEnumerable<SimpleAnimeSinopseDTO> sinopses,
            IEnumerable<SimpleCoverDTO> covers,
            IEnumerable<SimpleAnimeScreenshotDTO> screenshots,
            IEnumerable<SimpleEpisodeDTO> episodes,
            IEnumerable<SimpleAuthorDTO> authors,
            IEnumerable<SimpleRatingDTO> rating,
            IEnumerable<SimpleGenreDTO> genres,
            SimpleStudioDTO studio,
            EnumDTO<AnimeStatus> status,
            long? id, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Titles = titles;
            Sinopses = sinopses;
            Covers = covers;
            Screenshots = screenshots;
            Episodes = episodes;
            Authors = authors;
            Rating = rating;
            Genres = genres;
            Studio = studio;
            Status = status;
        }

        /// <summary>
        /// Cria uma instância de AnimeDTO com os parâmetros informados e retorna a instância criada.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="covers"></param>
        /// <param name="screenshots"></param>
        /// <param name="episodes"></param>
        /// <param name="authors"></param>
        /// <param name="rating"></param>
        /// <param name="genres"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public static DetailedAnimeDTO Create(
            IEnumerable<SimpleAnimeTitleDTO> titles,
            IEnumerable<SimpleAnimeSinopseDTO> sinopses,
            IEnumerable<SimpleCoverDTO> covers,
            IEnumerable<SimpleAnimeScreenshotDTO> screenshots,
            IEnumerable<SimpleEpisodeDTO> episodes,
            IEnumerable<SimpleAuthorDTO> authors,
            IEnumerable<SimpleRatingDTO> rating,
            IEnumerable<SimpleGenreDTO> genres,
            SimpleStudioDTO studio,
            EnumDTO<AnimeStatus> status,
            long? id, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedAnimeDTO(titles, sinopses, covers, screenshots, episodes, authors, rating, genres, studio, status, id, creationDate, updateDate);
        }
    }
}
