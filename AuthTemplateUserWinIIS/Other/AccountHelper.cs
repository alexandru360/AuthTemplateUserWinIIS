using System.Security.Principal;

namespace AuthTemplateUserWinIIS.Other
{
    public class AccountHelper
    {
        /// <summary>
        /// Returns the name of the windows account
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetWinAuthAccount(HttpContext context)
        {
            IPrincipal p = context.User;
            return p.Identity.Name;
        }
    }
}
