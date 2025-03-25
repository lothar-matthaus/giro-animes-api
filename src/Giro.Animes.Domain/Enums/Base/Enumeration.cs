using System.Reflection;

namespace Giro.Animes.Domain.Enums.Base
{
    public abstract class Enumeration<TEnum, TValue> : IComparable where TEnum : Enumeration<TEnum, TValue> where TValue : IComparable
    {
        private static readonly Dictionary<TValue, TEnum> _items = new Dictionary<TValue, TEnum>();
        public TValue Value { get; }
        public string Name { get; }

        protected Enumeration(TValue value, string name)
        {
            Value = value;
            Name = name;
            // Registra a instância no dicionário.
            _items[value] = (TEnum)this;
        }

        public static TEnum FromValue(TValue value)
        {
            if (_items.TryGetValue(value, out var item))
                return item;

            throw new ArgumentException($"Nenhuma instância de {typeof(TEnum).Name} foi encontrada para o valor '{value}'.");
        }

        /// <summary>
        /// Retorna todas as instâncias da smart enum
        /// </summary>
        public static IEnumerable<TEnum> List => _items.Values;

        /// <summary>
        /// Sobrescreve o método ToString para retornar o nome da instância
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        // Permite comparar os objetos com base no Id
        public int CompareTo(object? other) => Value.CompareTo((other as Enumeration<TEnum, TValue>).Value);

        // Método para retornar todas as instâncias de uma smart enum
        public static IEnumerable<T> GetAll<T>() where T : Enumeration<TEnum, TValue> =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();
    }
}
