using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Constants
{
    public static class Policies
    {
        public const string CLAIM_NAME = "Permission";
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
            public const string CAN_GET_ALL = "Account:CanGetAll";
            public const string CAN_GET_DETAIL = "Account:CanGetDetail";
            public const string CAN_CREATE = "Account:CanCreate";
            public const string CAN_UPDATE = "Account:CanUpdate";
            public const string CAN_DELETE = "Account:CanDelete";
        }
    }
}
