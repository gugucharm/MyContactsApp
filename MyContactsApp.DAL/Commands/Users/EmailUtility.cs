namespace MyContactsApp.DAL.Commands.Users
{
    // This static class enables checking the validity
    // of an email before registering a new User
    public static class EmailUtility
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
