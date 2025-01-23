using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Arma : Item
    {
        public int DanoMaximo { get; set; }
        public int DanoMinimo { get; set; }

        public Arma(int id, string nome, string nomeplural, int danoMaximo, int danoMinimo) : base(id, nome, nomeplural)
        {
            DanoMaximo = danoMaximo;
            DanoMinimo = danoMinimo;
        }
    }
}
