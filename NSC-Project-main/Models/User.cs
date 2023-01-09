using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\\(?(\[0-9\]{3})\\)?\[-.●\]?(\[0-9\]{3})\[-.●\]?(\[0-9\]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string? PhoneNumber { get; set; }

        public ICollection<Reservetion>? Reservetions { get; set; }
       
    }
}
