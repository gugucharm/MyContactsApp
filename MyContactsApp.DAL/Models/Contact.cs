namespace MyContactsApp.DAL.Models
{
    // We define two foreign keys for the Contact model
    // and a Category type field to include all concerned
    // information in response when fetching Contacts
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Category Category { get; set; }
    }
}
