namespace MyContactsApp.DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public string Subcategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
