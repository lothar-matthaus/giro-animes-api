using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear Enumerações para EnumDTO
    /// </summary>
    internal static class EnumerationMapper
    {

        /// <summary>
        /// Método responsável por mapear uma enumeração para um EnumDTO
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static EnumDTO<TEnum> Map<TEnum>(this TEnum enumeration) where TEnum : Enum
        {
            EnumDTO<TEnum> enumDTO = EnumDTO<TEnum>.Create(enumeration, enumeration.ToString());

            return enumDTO;
        }
    }
}
