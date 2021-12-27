using System.ComponentModel.DataAnnotations;

namespace AddressBookWebApp.Model
{
    public class AddressBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress, Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
