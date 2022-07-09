
using System.ComponentModel.DataAnnotations;


namespace DungeonFinderWebApp.Domain.Models.Request
{
    public class RegisterRequest
    {   
        [Required]
        [DataType(DataType.EmailAddress)]   
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As Senhas não são iguais!")]
        public string ConfirmPassword { get; set; }
    }
}
