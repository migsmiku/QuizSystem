namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Xml.Linq;

    public class User
    {
        public int UserID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserRoleId { get; set; }
    }
}