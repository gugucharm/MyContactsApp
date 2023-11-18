namespace MyContactsApp.DAL.Exceptions
{
    public class InsecurePasswordException : Exception
    {
        public InsecurePasswordException(string message) : base(message)
        {
        }
    }
}
