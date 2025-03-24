using Giro.Animes.Domain.Enums.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Enums
{
    public class UserTheme : Enumeration<UserTheme, int>
    {
        /// <summary>
        /// Define o tema automaticamente de acordo com o sistema operacional
        /// </summary>
        public static UserTheme Auto = new UserTheme(0, "Auto");
        /// <summary>
        /// Define o tema claro para o aplicativo (padrão)
        /// </summary>
        public static UserTheme Light = new UserTheme(1, "Light");
        /// <summary>
        /// Define o tema escuro para o aplicativo (modo noturno)
        /// </summary>
        public static UserTheme Dark = new UserTheme(2, "Dark");

        /// <summary>
        ///  Construtor privado para inicializar as propriedades
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        private UserTheme(int value, string name) : base(value, name) { }
    }
}
