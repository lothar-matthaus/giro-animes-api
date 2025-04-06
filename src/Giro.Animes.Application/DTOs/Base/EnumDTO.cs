namespace Giro.Animes.Application.DTOs.Base
{
    public class EnumDTO<TEnum> where TEnum : Enum
    {
        /// <summary>
        /// Identificador do enum
        /// </summary>
        public TEnum Key { get; private set; }
        /// <summary>
        /// Valor do enum em string
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Construtor privado para evitar instâncias fora da classe EnumDTO
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private EnumDTO(TEnum key, string value)
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
        public static EnumDTO<TEnum> Create(TEnum key, string value)
        {
            return new EnumDTO<TEnum>(key, value);
        }
    }
}
