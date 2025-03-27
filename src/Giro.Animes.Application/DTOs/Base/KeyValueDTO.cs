using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Base
{
    /// <summary>
    /// Represents a data transfer object with a key and a value.
    /// </summary>
    public class KeyValueDTO
    {
        /// <summary>
        /// Gets the key of the key-value pair.
        /// </summary>
        public long Key { get; private set; }

        /// <summary>
        /// Gets the value of the key-value pair.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the KeyValueDTO class.
        /// </summary>
        /// <param name="key">The key of the key-value pair.</param>
        /// <param name="value">The value of the key-value pair.</param>
        private KeyValueDTO(long key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Creates a new instance of the KeyValueDTO class.
        /// </summary>
        /// <param name="key">The key of the key-value pair.</param>
        /// <param name="value">The value of the key-value pair.</param>
        /// <returns>A new instance of KeyValueDTO.</returns>
        public static KeyValueDTO Create(long key, string value) => new KeyValueDTO(key, value);
    }
}
