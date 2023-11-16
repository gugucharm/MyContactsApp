namespace MyContactsApp.DAL.DTOs
{
    public class ContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
