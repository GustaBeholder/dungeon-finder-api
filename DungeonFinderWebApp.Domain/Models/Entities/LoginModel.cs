using System.ComponentModel.DataAnnotations;


namespace DungeonFinderWebApp.Domain.Models.Entities
{
    public class LoginModel
    {
        public string Name = "Teste";
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
