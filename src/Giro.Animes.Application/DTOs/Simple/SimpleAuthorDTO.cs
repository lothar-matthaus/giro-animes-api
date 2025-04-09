using Giro.Animes.Application.DTOs.Base;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAuthorDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Nome do autor.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Pseudônimo do autor.
        /// </summary>
        public string PenName { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que a classe só pode ser instanciada através do método Create.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="penName"></param>
        /// <param name="id"></param>
        private SimpleAuthorDTO(string name, string penName, long? id) : base(id)
        {
            Name = name;
            PenName = penName;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleAuthorDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="penName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleAuthorDTO Create(string name, string penName, long? id)
        {
            return new SimpleAuthorDTO(name, penName, id);
        }
    }
}
