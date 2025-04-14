namespace Giro.Animes.Application.Constants
{
    public static class Messages
    {
        public static class Response
        {
            public const string SUCCESS = "Operação realizada com sucesso";
            public const string NOT_FOUND = "Nenhum resultado encontrado";
            public const string BAD_REQUEST = "Erro ao realizar operação";
            public static class Author
            {
                public const string AUTHOR_NOT_FOUND = "Autor não encontrado";
                public const string AUTHOR_FOUND = "Autor encontrado com sucesso";
                public const string AUTHORS_FOUND = "Autores encontrados com sucesso";
                public const string AUTHORS_NOT_FOUND = "Nenhum autor encontrado";
            }
            public static class Account
            {
                public const string ACCOUNT_NOT_FOUND = "Conta não encontrada";
                public const string ACCOUNT_FOUND = "Conta encontrada com sucesso";
                public const string ACCOUNTS_FOUND = "Contas encontradas com sucesso";
                public const string ACCOUNTS_NOT_FOUND = "Nenhuma conta encontrada";
                public const string ACCOUNT_CREATED = "Conta criada com sucesso";
                public const string ACCOUNT_NOT_CREATED = "Não foi possível criar a conta.";
                public const string ACCOUNT_UPDATED = "Conta atualizada com sucesso";
                public const string PASSWORD_UPDATED = "Senha atualizada com sucesso";
                public const string SETTINGS_UPDATED = "Configurações atualizadas com sucesso";
                public const string SETTINGS_NOT_UPDATED = "Não foi possível atualizar as configurações";
            }

            public static class Auth
            {
                public const string AUTHENTICATION_SUCCESS = "Autenticação realizada com sucesso";
                public const string AUTHENTICATION_FAILED = "Falha na autenticação";
            }

            public static class Anime
            {
                public const string ANIME_NOT_FOUND = "Anime não encontrado";
                public const string ANIME_FOUND = "Anime encontrado com sucesso";
                public const string ANIMES_FOUND = "Animes encontrados com sucesso";
                public const string ANIMES_NOT_FOUND = "Nenhum anime encontrado";
                public const string ANIME_CREATED = "Anime criado com sucesso";
                public const string ANIME_NOT_CREATED = "Não foi possível criar o anime";
            }

            public static class Language
            {
                public const string LANGUAGE_NOT_FOUND = "Idioma não encontrado";
                public const string LANGUAGE_FOUND = "Idioma encontrado com sucesso";
                public const string LANGUAGES_FOUND = "Idiomas encontrados com sucesso";
                public const string LANGUAGES_NOT_FOUND = "Nenhum idioma encontrado";
            }
        }
    }
}
