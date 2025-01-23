using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Jogador : Criatura
    {
        public int Dinheiro { get; set; }
        public int PontosXP { get; set; }
        public int Nivel { get; set; }
        public Local LocalAtual { get; set; }
        public List<ItemInventario> Inventario { get; set; }
        public List<QuestJogador> Quests { get; set; }

        public Jogador(int saudeAtual, int saudeMaxima, int dinheiro, int pontosXP, int nivel) : base(saudeAtual, saudeMaxima)
        {
            Dinheiro = dinheiro;
            PontosXP = pontosXP;
            Nivel = nivel;

            Inventario = new List<ItemInventario>();
            Quests = new List<QuestJogador>();
        }

        public bool TemItemNecessarioParaEntrar(Local local)
        {
            if (local.ItemParaEntrar == null)
            {
                // Não há item exigido para este local, então retornar true
                return true;
            }

            // Ver se o jogador tem o item no inventario
            foreach (ItemInventario ii in Inventario)
            {
                if (ii.Detalhes.ID == local.ItemParaEntrar.ID)
                {
                    // Item exigido foi encontrado, retornar true
                    return true;
                }
            }

            // O item não foi encontrado no inventário, por isso retornar false
            return false;
        }

        public bool TemQuest(Quest quest)
        {
            foreach (QuestJogador questJogador in Quests)
            {
                if (questJogador.Detalhes.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletouQuest(Quest quest)
        {
            foreach (QuestJogador questJogador in Quests)
            {
                if (questJogador.Detalhes.ID == quest.ID)
                {
                    return questJogador.EstaCompleta;
                }
            }

            return false;
        }

        public bool TemItensParaCompletarQuest(Quest quest)
        {
            // Ver se o jogador tem todos os itens necessarios para concluir a quest
            foreach (ItemConclusaoQuest icq in quest.ItensConclusaoQuest)
            {
                bool encontrouItemNoInventario = false;

                // Verificar cada item no inventário do jogador, para ver se ele tem o item e em quantidade suficiente
                foreach (ItemInventario ii in Inventario)
                {
                    // O jogador tem o item no inventário
                    if (ii.Detalhes.ID == icq.Detalhes.ID)
                    {
                        encontrouItemNoInventario = true;

                        if (ii.Quantidade < icq.Quantidade)
                        {
                            // O jogador não tem o bastante do item para completar a quest
                            return false;
                        }
                    }
                }

                // Não foi encontrado nenhum do item
                if (!encontrouItemNoInventario)
                {
                    return false;
                }
            }

            // Chegando aqui, o jogador tem todos os itens para completar a quest
            return true;
        }
        public void RemoverItemExigidoPelaQuest(Quest quest)
        {
            foreach (ItemConclusaoQuest icq in quest.ItensConclusaoQuest)
            {
                foreach (ItemInventario ii in Inventario)
                {
                    if (ii.Detalhes.ID == icq.Detalhes.ID)
                    {
                        // Subtrair a quantidade do inventário do jogador que foi exigida pela quest
                        ii.Quantidade -= icq.Quantidade;
                        break;
                    }
                }
            }
        }

        public void AdicionarItemAoInventario(Item itemAdd)
        {
            foreach (ItemInventario ii in Inventario)
            {
                if (ii.Detalhes.ID == itemAdd.ID)
                {
                    // Ele já tem o item no inventário, então aumentar a quantidade em 1
                    ii.Quantidade++;

                    return; // Item adicionado, então sair da função
                }
            }

            // Ele não tinha o item, então adicionar o item com quantidade 1
            Inventario.Add(new ItemInventario(itemAdd, 1));
        }

        public void MarcarQuestCompleta(Quest quest)
        {
            // Encontrar a quest na lista de quests do jogador
            foreach (QuestJogador qp in Quests)
            {
                if (qp.Detalhes.ID == quest.ID)
                {
                    // Marcar como completa
                    qp.EstaCompleta = true;

                    return; // Quest encontrada e marcada como completa, então sair da função
                }
            }
        }

    }
}
