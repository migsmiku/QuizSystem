namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterModel : Users
    {
        [Required]
        public new string? FirstName { get; set; }
        [Required]
        public new string? LastName { get; set; }
        [Required]
        public new string? Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public new DateTime DateOfBirth { get; set; }
    }
}