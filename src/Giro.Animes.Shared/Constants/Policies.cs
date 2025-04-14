namespace Giro.Animes.Shared.Constants
{
    public static class Policies
    {
        public const string CLAIM_NAME = "Permission";
        public const string CAN_DO_ALL = "CanDoAll";
        public static class Animes
        {
            public const string CAN_GET_ALL = "Animes:CanGetAll";
            public const string CAN_GET_DETAIL = "Animes:CanGetDetail";
            public const string CAN_CREATE = "Animes:CanCreate";
            public const string CAN_UPDATE = "Animes:CanUpdate";
            public const string CAN_DELETE = "Animes:CanDelete";
        }

        public static class Authors
        {
            public const string CAN_GET_ALL = "Authors:CanGetAll";
            public const string CAN_GET_DETAIL = "Authors:CanGetDetail";
            public const string CAN_CREATE = "Authors:CanCreate";
            public const string CAN_UPDATE = "Authors:CanUpdate";
            public const string CAN_DELETE = "Authors:CanDelete";
        }

        public static class Account
        {
            public const string CAN_GET_ALL = "Accounts:CanGetAll";
            public const string CAN_GET_DETAIL = "Accounts:CanGetDetail";
            public const string CAN_CREATE = "Accounts:CanCreate";
            public const string CAN_UPDATE = "Accounts:CanUpdate";
            public const string CAN_DELETE = "Accounts:CanDelete";
        }
    }
}
