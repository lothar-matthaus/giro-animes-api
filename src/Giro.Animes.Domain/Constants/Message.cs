﻿namespace Giro.Animes.Domain.Constants
{
    internal static class Message
    {
        public static class Account
        {
            public const string ACCOUNT_NOT_FOUND = "Conta não encontrada";
            public const string LOGIN_OR_PASSWORD_INVALID = "Usuário ou senha inválidos";
            public const string ACCOUNT_NOT_CONFIRMED = "A conta precisa ser confirmada. Verifique sua caixa de entrada.";
            public const string ACCOUNT_ALREADY_CONFIRMED = "A conta já foi confirmada.";
        }

        public static class User
        {
            public const string USER_ROLE_NOT_ALLOWED = "O usuário não tem permissão para acessar este recurso.";
        }

        public static class Language
        {
            public const string LANGUAGE_NOT_FOUND = "Idioma não encontrado";
            public const string LANGUAGES_NOT_FOUND = "Idiomas não encontrados";
        }

        public static class Studio
        {
            public const string STUDIO_NOT_FOUND = "Estúdio não encontrado";
            public const string STUDIOS_NOT_FOUND = "Estúdios não encontrados";
        }
        public static class Author
        {
            public const string AUTHOR_NOT_FOUND = "Autor não encontrado";
            public const string AUTHORS_NOT_FOUND = "Autores não encontrados";
        }

        public static class Genre
        {
            public const string GENRE_NOT_FOUND = "Gênero não encontrado";
            public const string GENRES_NOT_FOUND = "Gêneros não encontrados";
        }

        public static class Anime
        {
            public const string ANIME_NOT_FOUND = "Anime não encontrado";
            public const string ANIMES_NOT_FOUND = "Animes não encontrados";
            public const string ANIME_ALREADY_EXISTS = "Anime já existe";
            public const string ANIME_TITLE_ALREADY_EXISTS = "Título do anime já existe";
            public const string ANIME_SINOPSE_ALREADY_EXISTS = "Sinopse do anime já existe";
        }

        internal static class Validation
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
                public const string INVALID_CURRENT_PASSWORD = "A senha atual está incorreta. Por favor, verifique e tente novamente.";
            }

            public static class Anime
            {
                public const string TITLE_REQUIRED = "O anime precisa ter ao menos um título.";
                public const string AUTHOR_REQUIRED = "O anime precisa ter ao menos um autor.";
                public const string GENRE_REQUIRED = "O anime precisa ter ao menos um gênero.";
                public const string STUDIO_REQUIRED = "O anime precisa ter um estúdio associado.";
                public const string INVALID_STATUS = "O status do anime é inválido.";
                public const string DUPLICATED_LANGUAGE = "{0} possuem idiomas duplicados. Só deve haver apenas um idioma para cada.";
                public const string DUPLICATED_AUTHORS = "Os anime possui autores duplicados.";
                public const string DUPLICATED_GENRES = "Os anime possui gêneros duplicados.";
            }

            public static class Language
            {
                public const string NAME_LENGHT = "O nome do idioma deve conter entre 3 e 50 caracteres";
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

            public static class User
            {
                public const string INVALID_NAME = "O nome de usuário pode conter apenas letras, números e símbolos permitidos (como !@#$%^&*(),._-).";
                public const string INVALID_NAME_LENGHT = "O nome do usuário deve conter entre 3 e 20 caracteres";
                public const string USERNAME_ALREADY_EXISTS = "Nome de usuário já existe";
                public const string EMAIL_ALREADY_EXISTS = "E-mail já existe";
            }

            public static class Studio
            {
                public const string INVALID_NAME = "O nome do estúdio deve conter apenas letras separadas por espaços";
                public const string INVALID_NAME_LENGHT = "O nome do autor deve conter entre 3 e 50 caracteres";
            }
            public static class Description
            {
                public const string LANGUAGE_REQUIRED = "O idioma da descrição é obrigatório";
            }

            public static class Title
            {
                public const string ANIME_REQUIRED = "O anime é obrigatório";
                public const string LANGUAGE_REQUIRED = "O idioma do título é obrigatório";
                public const string TITLE_LENGHT = "O título em '{0}' deve conter entre 3 e 100 caracteres";
            }
        }
    }
}
