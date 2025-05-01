using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    /// <summary>
    /// Objeto de Transferência de Dados simples para a sinopse de uma temporada.
    /// </summary>
    public class SimpleSeasonSinopseDTO : SimpleDescriptionDTO
    {
        /// <summary>
        /// Construtor privado com parâmetros. Garante que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        private SimpleSeasonSinopseDTO(string text, SimpleLanguageDTO language, long? id) : base(text, language, id)
        {
        }

        /// <summary>
        /// Método de fábrica para criar uma instância de SimpleSeasonSinopseDTO com os parâmetros informados e retorna a instância criada.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleSeasonSinopseDTO Create(string text, SimpleLanguageDTO language, long? id)
        {
            return new SimpleSeasonSinopseDTO(text, language, id);
        }
    }
}
