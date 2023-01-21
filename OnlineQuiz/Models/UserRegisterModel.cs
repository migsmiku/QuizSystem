namespace OnlineQuiz.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Cryptography.X509Certificates;

    [NotMapped]
    public class UserRegisterModel : Users
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        [Compare("Password",ErrorMessage ="Password Not Match")]
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, Phone]
        public string? Phone { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}