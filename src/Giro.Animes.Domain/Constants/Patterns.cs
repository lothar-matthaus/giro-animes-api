namespace Giro.Animes.Domain.Constants
{
    internal static class Patterns
    {
        public static class General
        {
            public const string URL = @"^(https?:\/\/)?(www\.)?[a-zA-Z0-9-]{2,40}\.[a-z]{2,6}(\S*)?$";
            public const string URL_INSTAGRAM = @"^(https?:\/\/)?(www\.)?instagram\.com\/[a-zA-Z0-9_.]+\/?$";
            public const string URL_TWITTER = @"^(https?:\/\/)?(www\.)?(twitter\.com|x\.com)\/[a-zA-Z0-9_]+\/?$";
        }
        public static class Anime
        {
            public const string TITLE = @"^.{3,100}$";
        }

        public static class Account
        {
            public const string EMAIL = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            public const string PASSWORD = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        }

        public static class Language
        {
            public const string NAME = @"^.{3,50}$";
            public const string CODE = @"^[a-z]{2}-[A-Z]{2}$";
            public const string NATIVE_NAME = @"^.{3,50}$";
        }

        public static class Author
        {
            public const string NAME = @"^[\p{L}]{3,}(?: [\p{L}]+){0,6}$";
            public const string NAME_LENGHT = @"^.{3,50}$";
            public const string PEN_NAME = @"^[\p{L}]+(?: [\p{L}]+)*$";
            public const string PEN_NAME_LENGHT = @"^.{3,30}$";
        }

        public static class Cover
        {
            public const string ALLOWED_EXTENSIONS = @"^image\/(jpeg|jpg|gif)$";
            public const string FILE_NAME_LENGTH = @"^.{3,100}$";
        }

        public static class User
        {
            public const string NAME = @"^[a-zA-Z0-9!@#$%^&*(),.?"":{}|<>_-]+$";
            public const string NAME_LENGHT = @"^.{3,20}$";
        }

        public static class Studio
        {
            public const string NAME = @"^[A-Za-z0-9À-ÿ\s\-'&]+$";
            public const string NAME_LENGHT = @"^.{3,30}$";
        }
    }
}