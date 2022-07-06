namespace DungeonFinderAPI.Model.Response
{
    public class MesaResponse : BaseResponse
    {
        public int IdMesa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string QtdJogadores { get; set; }
        public string QtdMaxJogadores { get; set; }
        public string Sistema { get; set; }
        public string Mestre { get; set; }


       
    }
}
