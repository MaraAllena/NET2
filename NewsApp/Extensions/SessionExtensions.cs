using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp
{
    public static class SessionExtensions
    {
        public static void SetUserEmail(this ISession session, string email)
        {
            session.SetString("email", email);

        }

        public static string GetUserEmail(this ISession session)
        {
            return session.GetString("email");
        }

        
        public static void SetIsAdmin(this ISession session, bool isAdmin)
        {
            session.SetInt32("isAdmin", isAdmin ? 1 : 0);

        }
        public static bool GetIsAdmin(this ISession session)
        {
            //return session.GetInt32("isAdmin") == 1 ? true: false;
            return session.GetInt32("isAdmin") == 1;

        }


    }
}
