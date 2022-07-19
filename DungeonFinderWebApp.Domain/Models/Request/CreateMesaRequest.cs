
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DungeonFinderWebApp.Domain.Models.Request
{
    public class CreateMesaRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int QtdMaxJogadores { get; set; }
        public int idMestre { get; set; }
        [Required]
        [Display(Name = "Sistema")]
        public int idSistema { get; set; }
        public string DisplayPic { get; set; }

    }
}
