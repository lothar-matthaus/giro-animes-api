﻿using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class AnimeSinopseDTO : DescriptionDTO
    {

        /// <summary>  
        /// Identificador do anime ao qual a descrição pertence  
        /// </summary>  
        public long AnimeId { get; private set; }

        private AnimeSinopseDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, string text, LanguageDTO language) : base(id, creationDate, updateDate, deletionDate, text, language)
        {
            AnimeId = animeId;
        }
        public static AnimeSinopseDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, string text, LanguageDTO language)
            => new AnimeSinopseDTO(id, creationDate, updateDate, deletionDate, animeId, text, language);
    }
}