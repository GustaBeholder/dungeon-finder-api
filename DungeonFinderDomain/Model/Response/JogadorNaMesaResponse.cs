namespace DungeonFinderDomain.Model.Response
{
    public class JogadorNaMesaResponse
    {
        public int idJogador { get; set; }
        public int idMesa { get; set; }
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime AdcionadoEm { get; set; }
    }
}
