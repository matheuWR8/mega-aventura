using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemInventario
    {
        public Item Detalhes { get; set; }
        public int Quantidade { get; set; }

        public ItemInventario(Item detalhes, int quantidade)
        {
            Detalhes = detalhes;
            Quantidade = quantidade;
        }
    }
}
