using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }

            public static class Auth
            {
                public const string AUTHENTICATION_SUCCESS = "Autenticação realizada com sucesso";
            }
        }
    }
}
