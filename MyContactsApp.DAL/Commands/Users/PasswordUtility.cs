using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactsApp.DAL.Commands.Users
{
    // This static class enables checking the validity
    // of a password before registering a new User
    public static class PasswordUtility
    {
        public static bool IsPasswordSecure(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }

}
