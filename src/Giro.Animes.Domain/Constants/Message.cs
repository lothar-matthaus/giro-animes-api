namespace Giro.Animes.Domain.Constants
{
    public static class Message
    {
        public static class Validation
        {
            public static class General
            {
                public const string REQUIRED = "Campo '{0}' é obrigatório";
                public const string INVALID = "Campo '{0}' é inválido";
                public const string INVALID_URL = "URL inválida";
            }
            public static class Account
            {
                public const string INVALID_PASSWORD = "A senha deve conter no mínimo 8 caracteres, incluindo pelo menos uma letra maiúscula, um número e um caractere especial (@, $, !, %, *, ?, &).";
                public const string INVALID_PASSWORD_CONFIRM = "As senhas não conferem. Por favor, verifique se ambas as senhas são idênticas e tente novamente.";
            }

            public static class Anime
            {
                public const string TITLE_LENGHT = "O título do anime deve conter entre 3 e 100 caracteres";
            }

            public static class Language
            {
                public const string NAME_LENGHT = "O nome do idioma deve conter entre 3 e 20 caracteres";
                public const string CODE_FORMAT = "O código do idioma deve seguir o padrão xx-XX";
                public const string CODE_LENGHT = "O código do idioma deve conter 5 caracteres";
            }

            public static class Author
            {
                public const string INVALID_NAME = "O nome do autor deve conter apenas letras separadas por espaços";
                public const string INVALID_NAME_LENGHT = "O nome do autor deve conter entre 3 e 50 caracteres";
                public const string INVALID_PEN_NAME = "O pseudônimo do autor deve conter apenas letras separadas por espaços";
                public const string INVALID_PEN_NAME_LENGHT = "O pseudônimo do autor deve conter entre 3 e 30 caracteres";
            }
            public static class Cover
            {
                public const string INVALID_EXTENSION = "A extensão do arquivo de capa informado não é suportado.";
                public const string INVALID_FILE_NAME_LENGHT = "O nome do arquivo de capa deve conter entre 3 e 100 caracteres";
            }

            public static class User
            {
                public const string INVALID_NAME = "O nome de usuário pode conter apenas letras, números e símbolos permitidos (como !@#$%^&*(),._-).";
                public const string INVALID_NAME_LENGHT = "O nome do usuário deve conter entre 3 e 20 caracteres";
            }

            public static class Studio
            {
                public const string INVALID_NAME = "O nome do estúdio deve conter apenas letras separadas por espaços";
                public const string INVALID_NAME_LENGHT = "O nome do autor deve conter entre 3 e 50 caracteres";
            }
        }
    }
}
