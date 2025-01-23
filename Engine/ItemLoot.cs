using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemLoot
    {
        public Item Detalhes { get; set; }
        public int ChanceDrop { get; set; }
        public bool EhItemPadrao { get; set; }
        public ItemLoot(Item detalhes, int chanceDrop, bool ehItemPadrao)
        {
            Detalhes = detalhes;
            ChanceDrop = chanceDrop;
            EhItemPadrao = ehItemPadrao;
        }
    }
}
