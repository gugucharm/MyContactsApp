namespace MyContactsApp.DAL.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message)
        {
        }
    }
}
