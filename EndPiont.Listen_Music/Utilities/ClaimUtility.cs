using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Utilities
{
    public static class ClaimUtilities
    {
        
        public static long GetUserId(ClaimsPrincipal User)
        {
            var ClaimsIdentity = User.Identity as ClaimsIdentity;
            long userId = long.Parse(ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }

        public static List<string> GetRolse(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                List<string> rolse = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    rolse.Add(item.Value);
                }
                return rolse;
            }
            catch (Exception )
            {
                return null;
            }

        }
    }
}
