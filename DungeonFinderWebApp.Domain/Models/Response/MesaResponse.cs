﻿
namespace DungeonFinderWebApp.Domain.Models.Response
{
    public class MesaResponse
    {
        public int IdMesa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QtdJogadores { get; set; }
        public int QtdMaxJogadores { get; set; }
        public string Sistema { get; set; }
        public bool isAtivo { get; set; }
        public int IdMestre { get; set; }
        public string Mestre { get; set; }
        public string DisplayPic { get; set; }

    }
}
