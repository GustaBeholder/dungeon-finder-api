using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonFinderDomain.Model.Requests
{
    public class UpdateMesa
    {
        public int IdMesa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int isAtivo { get; set; }
        public int QtdMaxJogadores { get; set; }
    }
}
