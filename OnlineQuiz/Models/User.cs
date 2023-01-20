namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Permissions;

    public class Users
    {
        [Key]
        public int UserID { get; set; }


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int UserRoleId { get; set; }

        [Required]
        [Display(Name = "UserName:")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string? Password { get; set; }

        [InverseProperty("Users")]
        public virtual QuizSubmissions? QuizSubmissions { get; set; }
    }
}