namespace Giro.Animes.Application.DTOs.Base
{
    public class EnumDTO<TKey> where TKey : IComparable
    {
        /// <summary>
        /// Identificador do enum
        /// </summary>
        public TKey Key { get; private set; }
        /// <summary>
        /// Valor do enum em string
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Construtor privado para evitar instâncias fora da classe EnumDTO
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private EnumDTO(TKey key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Método estático para criar instâncias de EnumDTO sem precisar instanciar a classe
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EnumDTO<TKey> Create(TKey key, string value)
        {
            return new EnumDTO<TKey>(key, value);
        }
    }
}
