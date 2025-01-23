using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Cura : Item
    {
        public int ValorCura { get; set; }

        public Cura(int id, string nome, string nomePlural, int valorCura) : base(id, nome, nomePlural){
            ValorCura = valorCura;
        }
    }
}
