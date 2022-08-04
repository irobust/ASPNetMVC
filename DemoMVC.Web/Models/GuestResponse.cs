using System.ComponentModel.DataAnnotations;
namespace DemoMVC.Web.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Pleae enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please entter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage="Please enter a valid email address")]
        public string Email { get; set; }

        public string? Phone { get; set; }

        public bool? WillAttend { get; set; }
    }
}
