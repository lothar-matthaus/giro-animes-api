using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Enums
{
    public enum TemplateType
    {
        None = 0,
        Welcome = 1,
        PasswordReset = 2,
        AccountVerification = 3,
        PasswordChange = 4,
        AccountDeactivation = 5,
        AccountReactivation = 6,
        SubscriptionConfirmation = 7,
        SubscriptionCancellation = 8,
        SubscriptionRenewal = 9,
        SubscriptionUpgrade = 10,
        SubscriptionDowngrade = 11,
        WatchlistAnimeUpdated = 12,
        AccountConfirmed = 13
    }
}
