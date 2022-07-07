namespace DungeonFinderDomain.Model.Requests
{
    public class MesaCreateRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QtdMaxJogadores { get; set; }
        public int idMestre { get; set; }
        public int idSistema { get; set; }
    }
}
