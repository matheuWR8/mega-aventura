using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Mundo
    {
        public static readonly List<Item> Itens = new List<Item>();
        public static readonly List<Monstro> Monstros = new List<Monstro>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Local> Locais = new List<Local>();

        public const int ITEM_ID_ESPADA_ENFERRUJADA = 1;
        public const int ITEM_ID_TRAPO = 2;
        public const int ITEM_ID_PELE = 3;
        public const int ITEM_ID_OSSO = 4;
        public const int ITEM_ID_PAU = 5;
        public const int ITEM_ID_ESPADA = 6;
        public const int ITEM_ID_PANELA = 7;
        public const int ITEM_ID_CESTO = 8;
        public const int ITEM_ID_PREGO = 9;
        public const int ITEM_ID_CHAVE = 10;
        public const int ITEM_ID_POCAO_CURA = 11;
        public const int ITEM_ID_RABO_RATO = 12;
        public const int ITEM_ID_OLHO_ARANHA = 13;

        public const int MONSTRO_ID_RATAZANA = 1;
        public const int MONSTRO_ID_ARANHA = 2;
        public const int MONSTRO_ID_GOBLIN = 3;
        public const int MONSTRO_ID_ESQUELETO = 4;

        public const int QUEST_ID_CACA_AS_ARANHAS = 1;
        public const int QUEST_ID_LIBERAR_CAVERNA = 2;
        public const int QUEST_ID_CONTROLE_DE_PRAGAS = 3;

        public const int LOCAL_ID_CASA = 1;
        public const int LOCAL_ID_CAMPO = 2;
        public const int LOCAL_ID_CIDADE = 3;
        public const int LOCAL_ID_TORRE_GUARDA = 4;
        public const int LOCAL_ID_CAVERNA = 5;
        public const int LOCAL_ID_CASA_ALQUIMISTA = 6;
        public const int LOCAL_ID_FLORESTA = 7;
        public const int LOCAL_ID_FAZENDA = 8;
        public const int LOCAL_ID_PLANTACAO = 9;

        static Mundo()
        {
            PopulaItens();
            PopulaMonstros();
            PopulaQuests();
            PopulaLocais();
        }

        private static void PopulaItens()
        {
            Itens.Add(new Arma(ITEM_ID_ESPADA_ENFERRUJADA, "Espada enferrujada", "Espadas enferrujadas", 4, 0));
            Itens.Add(new Item(ITEM_ID_TRAPO, "Trapo", "Trapos"));
            Itens.Add(new Item(ITEM_ID_PELE, "Pele", "Peles"));
            Itens.Add(new Item(ITEM_ID_OSSO, "Osso", "Ossos"));
            Itens.Add(new Arma(ITEM_ID_PAU, "Pau", "Paus", 5, 3));
            Itens.Add(new Arma(ITEM_ID_ESPADA, "Espada", "Espadas", 8, 3));
            Itens.Add(new Item(ITEM_ID_PANELA, "Panela", "Panelas"));
            Itens.Add(new Item(ITEM_ID_CESTO, "Cesto", "Cestos"));
            Itens.Add(new Item(ITEM_ID_PREGO, "Prego", "Pregos"));
            Itens.Add(new Item(ITEM_ID_CHAVE, "Chave", "Chaves"));
            Itens.Add(new Cura(ITEM_ID_POCAO_CURA, "Poção de cura", "Poções de cura", 5));
            Itens.Add(new Item(ITEM_ID_RABO_RATO, "Rabo de ratazana", "Rabos de ratazana"));
            Itens.Add(new Item(ITEM_ID_OLHO_ARANHA, "Olho de aranha", "Olhos de aranha"));
        }

        private static void PopulaMonstros()
        {
            Monstro ratazana = new Monstro(3, 3, MONSTRO_ID_RATAZANA, "Ratazana", 5, 3, 3);
            ratazana.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_RABO_RATO), 75, false));
            ratazana.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_PELE), 75, true));

            Monstro aranha = new Monstro(5, 5, MONSTRO_ID_ARANHA, "Aranha", 5, 5, 4);
            aranha.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_OLHO_ARANHA), 50, true));

            Monstro goblin = new Monstro(7, 7, MONSTRO_ID_GOBLIN, "Goblin", 6, 7, 13);
            goblin.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_PAU), 25, false));
            goblin.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_TRAPO), 75, true));

            Monstro esqueleto = new Monstro(9, 9, MONSTRO_ID_ESQUELETO, "Esqueleto", 7, 9,10);
            esqueleto.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_OSSO), 75, true));
            esqueleto.TabelaLoot.Add(new ItemLoot(ItemPorID(ITEM_ID_ESPADA_ENFERRUJADA), 20, false));

            Monstros.Add(ratazana);
            Monstros.Add(aranha);
            Monstros.Add(goblin);
            Monstros.Add(esqueleto);

        }

        private static void PopulaQuests()
        {
            Quest cacaAsAranhas =
                new Quest(QUEST_ID_CACA_AS_ARANHAS, "Caça às Aranhas", "Mate aranhas na floresta e traga 3 olhos de aranha para o alquimista.\n" +
                                                    "Recompensa: 1 poção de cura + 15 moedas de ouro.", 20, 15);
            cacaAsAranhas.ItensConclusaoQuest.Add(new ItemConclusaoQuest(ItemPorID(ITEM_ID_OLHO_ARANHA),3));
            cacaAsAranhas.RecompensaItem = ItemPorID(ITEM_ID_POCAO_CURA);

            Quest liberarCaverna =
                new Quest(QUEST_ID_LIBERAR_CAVERNA, "Libere a Caverna", "Mate os goblins que ocupam a caverna e traga 2 trapos.\n" +
                                                    "Recompensa: 1 espada + 30 moedas de ouro.", 40, 30);
            liberarCaverna.ItensConclusaoQuest.Add(new ItemConclusaoQuest(ItemPorID(ITEM_ID_TRAPO), 2));
            liberarCaverna.RecompensaItem = ItemPorID(ITEM_ID_ESPADA);

            Quest controlePragas =
                new Quest(QUEST_ID_CONTROLE_DE_PRAGAS, "Controle de Pragas", "Mate ratazanas na plantação e traga 4 rabos.\n" +
                                                       "Recompensa: 1 chave + 20 moedas de ouro", 20, 20);
            controlePragas.ItensConclusaoQuest.Add(new ItemConclusaoQuest(ItemPorID(ITEM_ID_RABO_RATO), 4));
            controlePragas.RecompensaItem = ItemPorID(ITEM_ID_CHAVE);

            Quests.Add(cacaAsAranhas);
            Quests.Add(liberarCaverna);
            Quests.Add(controlePragas);
        }

        private static void PopulaLocais()
        {
            Local casa = new Local(LOCAL_ID_CASA, "Casa", "Seu barraco.");

            Local campo = new Local(LOCAL_ID_CAMPO, "Campo", "Um extenso e lindo campo verdejante.");

            Local cidade = new Local(LOCAL_ID_CIDADE, "Cidade", "Um pequeno povoado, com algumas habitações e comércios.");

            Local torreGuarda = new Local(LOCAL_ID_TORRE_GUARDA, "Torre de guarda", "Esta torre serve de guarda contra ataques de goblins. O chefe da guarda vive aqui.");
            torreGuarda.QuestDisponivel = QuestPorID(QUEST_ID_LIBERAR_CAVERNA);

            Local caverna = new Local(LOCAL_ID_CAVERNA, "Caverna", "Um lugar escuro e tenebroso. Aqui habitam os goblins.");
            caverna.MonstroPresente = MonstroPorID(MONSTRO_ID_GOBLIN);

            Local alquimista = new Local(LOCAL_ID_CASA_ALQUIMISTA, "Casa do alquimista", "Aqui mora um sujeito incomum. Cuidado com as vidraças!");
            alquimista.QuestDisponivel = QuestPorID(QUEST_ID_CACA_AS_ARANHAS);

            Local floresta = new Local(LOCAL_ID_FLORESTA, "Floresta", "Muitas lendas sobre esse lugar. Além de aranhas gigantes. Estas não são lendas.");
            floresta.MonstroPresente = MonstroPorID(MONSTRO_ID_ARANHA);

            Local fazenda = new Local(LOCAL_ID_FAZENDA, "Fazenda", "Esta é a fazenda. O velho fazendeiro fuma seu cachimbo à porteira.");
            fazenda.QuestDisponivel = QuestPorID(QUEST_ID_CONTROLE_DE_PRAGAS);

            Local plantacao = new Local(LOCAL_ID_PLANTACAO, "Plantação", "Tanta coisa pra comer, não me admira as ratazanas estarem tão grandes!");
            plantacao.MonstroPresente = MonstroPorID(MONSTRO_ID_RATAZANA);


            casa.LocalAoNorte = campo;

            campo.LocalAoSul = casa;
            campo.LocalAoLeste = cidade;
            campo.LocalAoOeste = fazenda;

            cidade.LocalAoOeste = campo;
            cidade.LocalAoNorte = torreGuarda;
            cidade.LocalAoLeste = alquimista;

            torreGuarda.LocalAoNorte = caverna;
            torreGuarda.LocalAoSul = cidade;

            caverna.LocalAoSul = torreGuarda;

            alquimista.LocalAoOeste = cidade;
            alquimista.LocalAoSul = floresta;

            floresta.LocalAoNorte = alquimista;

            fazenda.LocalAoLeste = campo;
            fazenda.LocalAoNorte = plantacao;

            plantacao.LocalAoSul = fazenda;

            Locais.Add(casa);
            Locais.Add(campo); 
            Locais.Add(cidade); 
            Locais.Add(torreGuarda);
            Locais.Add(caverna);
            Locais.Add(alquimista);
            Locais.Add(floresta);
            Locais.Add(fazenda);
            Locais.Add(plantacao);

        }

        public static Item ItemPorID(int id)
        {
            foreach (Item item in Itens)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monstro MonstroPorID(int id)
        {
            foreach (Monstro monstro in Monstros)
            {
                if (monstro.ID == id)
                {
                    return monstro;
                }
            }

            return null;
        }

        public static Quest QuestPorID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Local LocalPorID(int id)
        {
            foreach (Local local in Locais)
            {
                if (local.ID == id)
                {
                    return local;
                }
            }

            return null;
        }


    }
}
