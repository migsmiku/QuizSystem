namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Xml.Linq;

    public class UserRegisterModel : User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}