using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Common.Role
{
    public class UserRoles
    {
        [Display(Name ="ادمین")]
        public const string Admin = "Admin";

        [Display(Name = "کاربر عادی")]
        public const string User = "User";

        [Display(Name = "هنرمند")]
        public const string Artist = "Artist";
    }
}
