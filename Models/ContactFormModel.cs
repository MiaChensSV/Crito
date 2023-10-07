using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactFormModel
    {
        [Display(Name = "Your Name*")]
        [Required(ErrorMessage = "Your name is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Your Email*")]
        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "You Must provide an valid email address.")] public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Something write *")]
        public string Message { get; set; } = null!;
        public string RedirectUrl { get; set; } = "/contact";
    }
}
