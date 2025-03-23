using System.Reflection;

namespace Giro.Animes.Domain.Enums.Base
{
    public abstract class Enumeration : IComparable
    {
        public int Id { get; }
        public string Name { get; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        // Permite comparar os objetos com base no Id
        public int CompareTo(object? other) => Id.CompareTo((other as Enumeration).Id);

        // Método para retornar todas as instâncias de uma smart enum
        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();
    }
}
