using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleEpisodeSinopseDTO : SimpleDescriptionDTO
    {
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <param name="episodeId"></param>
        private SimpleEpisodeSinopseDTO(string description, SimpleLanguageDTO language, long? id, long episodeId) : base(description, language, id)
        {
            EpisodeId = episodeId;
        }

        /// <summary>
        /// Cria uma instância de SimpleEpisodeSinopse com os parâmetros informados e retorna a instância criada.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <param name="episodeId"></param>
        /// <returns></returns>
        public static SimpleEpisodeSinopseDTO Create(string description, SimpleLanguageDTO language, long? id, long episodeId)
        {
            return new SimpleEpisodeSinopseDTO(description, language, id, episodeId);
        }
    }
}
