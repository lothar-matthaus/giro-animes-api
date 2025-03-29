using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear Enumerações para EnumDTO
    /// </summary>
    internal static class EnumerationMapper
    {
        /// <summary>
        /// Mapeia uma Enumeração para um EnumDTO 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static EnumDTO<TKey> Map<TEnum, TKey>(this Enumeration<TEnum, TKey> enumeration) where TKey : IComparable where TEnum : Enumeration<TEnum, TKey>
        {
            EnumDTO<TKey> enumDTO = EnumDTO<TKey>.Create(enumeration.Value, enumeration.Name);

            return enumDTO;
        }

        /// <summary>
        /// Mapeia uma lista de Enumerações para uma lista de EnumDTO
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerations"></param>
        /// <returns></returns>
        public static IEnumerable<EnumDTO<TKey>> Map<TEnum, TKey>(this IEnumerable<Enumeration<TEnum, TKey>> enumerations) where TKey : IComparable where TEnum : Enumeration<TEnum, TKey>
        {
            IEnumerable<EnumDTO<TKey>> result = enumerations.Select(e => e.Map());
            return result;
        }
    }
}
