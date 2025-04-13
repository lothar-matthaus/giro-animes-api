using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Requests.Account
{
    public class AccountUpdateRequest
    {
        #region Alteracao de Email
        public string Email { get; set; }
        #endregion
    }
}
