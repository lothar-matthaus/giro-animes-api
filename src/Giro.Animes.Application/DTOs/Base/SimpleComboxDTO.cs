using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Base
{
    public class SimpleComboxDTO : BaseSimpleDTO
    {
        public string Value { get; private set; }

        /// <summary>
        /// Cria uma instância de SimpleComboxDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        private SimpleComboxDTO(long id, string value) : base(id)
        {
            Value = value;
        }

        /// <summary>
        /// Cria uma instância de SimpleComboxDTO. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SimpleComboxDTO Create(long id, string value)
        {
            return new SimpleComboxDTO(id, value);
        }
    }
}
