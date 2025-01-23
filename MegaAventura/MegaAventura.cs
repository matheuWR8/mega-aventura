using Engine;
using System.Threading;

namespace MegaAventura
{
    public partial class MegaAventura : Form
    {
        private Jogador jogador;
        private Monstro monstroAtual;

        public MegaAventura()
        {
            InitializeComponent();

            jogador = new Jogador(10, 10, 20, 0, 1);
            MoverPara(Mundo.LocalPorID(Mundo.LOCAL_ID_CASA));
            jogador.Inventario.Add(new ItemInventario(Mundo.ItemPorID(Mundo.ITEM_ID_ESPADA_ENFERRUJADA), 1));

            lbl_saude.Text = jogador.SaudeAtual.ToString();
            lbl_dinheiro.Text = jogador.Dinheiro.ToString();
            lbl_exp.Text = jogador.PontosXP.ToString();
            lbl_nivel.Text = jogador.Nivel.ToString();



        }

        private void btNorte_Click(object sender, EventArgs e)
        {
            MoverPara(jogador.LocalAtual.LocalAoNorte);
        }

        private void btLeste_Click(object sender, EventArgs e)
        {
            MoverPara(jogador.LocalAtual.LocalAoLeste);
        }

        private void btSul_Click(object sender, EventArgs e)
        {
            MoverPara(jogador.LocalAtual.LocalAoSul);
        }

        private void btOeste_Click(object sender, EventArgs e)
        {
            MoverPara(jogador.LocalAtual.LocalAoOeste);
        }

        private void MoverPara(Local novoLocal)
        {

            if (!jogador.TemItemNecessarioParaEntrar(novoLocal))
            {
                // O item exigido não foi encontrado no inventário, então exibir uma mensagem e parar de tentar mover-se
                rtbMensagens.Text += "Você deve ter um " + novoLocal.ItemParaEntrar.Nome + " para entrar neste local." + Environment.NewLine;
                return;
            }

            // Atualizar a localização do jogador
            jogador.LocalAtual = novoLocal;

            // Exibir/ocultoar os botões de movimento disponíveis na localiza~ção atual
            btNorte.Visible = (novoLocal.LocalAoNorte != null);
            btLeste.Visible = (novoLocal.LocalAoLeste != null);
            btSul.Visible = (novoLocal.LocalAoSul != null);
            btOeste.Visible = (novoLocal.LocalAoOeste != null);

            // Exibir nome e descrição do local atual
            rtbLocal.Text = novoLocal.Nome + Environment.NewLine;
            rtbLocal.Text += novoLocal.Descricao + Environment.NewLine;

            // Curar completamente o jogador
            jogador.SaudeAtual = jogador.SaudeMaxima;

            // Atualizar os pontos de saúde na interface
            lbl_saude.Text = jogador.SaudeAtual.ToString();

            // O local tem uma quest?
            if (novoLocal.QuestDisponivel != null)
            {
                // Ver se o jogador já tem a quest e se já a completou
                bool jogadorJaTemQuest = jogador.TemQuest(novoLocal.QuestDisponivel);
                bool jogadorJaCompletouQuest = jogador.CompletouQuest(novoLocal.QuestDisponivel);

                // Ver se o jogador já tem a quest
                if (jogadorJaTemQuest)
                {
                    // Se o jogador ainda não completou a quest
                    if (!jogadorJaCompletouQuest)
                    {
                        // Ver se o jogador tem todos os itens para completar a quest
                        bool jogadorTemTodosItensQuest = jogador.TemItensParaCompletarQuest(novoLocal.QuestDisponivel);

                        // O jogador tem todos os itens necessários para completar a quest
                        if (jogadorTemTodosItensQuest)
                        {
                            // Exibir mensagem
                            rtbMensagens.Text += Environment.NewLine;
                            rtbMensagens.Text += "Você completou a quest '" + novoLocal.QuestDisponivel.Nome + "'." + Environment.NewLine;

                            // Remover itens da quest do inventário
                            jogador.RemoverItemExigidoPelaQuest(novoLocal.QuestDisponivel);

                            // Dar recompensas pela quest
                            rtbMensagens.Text += "Você recebeu: " + Environment.NewLine;
                            rtbMensagens.Text += novoLocal.QuestDisponivel.RecompensaXP.ToString() + "pontos de experiência" + Environment.NewLine;
                            rtbMensagens.Text += novoLocal.QuestDisponivel.RecompensaOuro.ToString() + " moedas de ouro" + Environment.NewLine;
                            rtbMensagens.Text += novoLocal.QuestDisponivel.RecompensaItem.Nome + Environment.NewLine;
                            rtbMensagens.Text += Environment.NewLine;

                            jogador.PontosXP += novoLocal.QuestDisponivel.RecompensaXP;
                            jogador.Dinheiro += novoLocal.QuestDisponivel.RecompensaOuro;

                            // Adicionar o item de recompensa ao inventário
                            jogador.AdicionarItemAoInventario(novoLocal.QuestDisponivel.RecompensaItem);

                            // Marcar a quest como completa
                            jogador.MarcarQuestCompleta(novoLocal.QuestDisponivel);
                        }
                    }
                }
                else
                {
                    // O jogador não tem a quest

                    // Exibir as mensagens
                    rtbMensagens.Text += "Você recebeu a quest '" + novoLocal.QuestDisponivel.Nome + "'." + Environment.NewLine;
                    rtbMensagens.Text += novoLocal.QuestDisponivel.Descricao + Environment.NewLine;
                    rtbMensagens.Text += "Para completá-la volte com: " + Environment.NewLine;
                    foreach (ItemConclusaoQuest icq in novoLocal.QuestDisponivel.ItensConclusaoQuest)
                    {
                        if (icq.Quantidade == 1)
                        {
                            rtbMensagens.Text += icq.Quantidade.ToString() + " " + icq.Detalhes.Nome + Environment.NewLine;
                        }
                        else
                        {
                            rtbMensagens.Text += icq.Quantidade.ToString() + " " + icq.Detalhes.NomePlural + Environment.NewLine;
                        }
                    }
                    rtbMensagens.Text += Environment.NewLine;

                    // Adicionar a quest à lista do jogador
                    jogador.Quests.Add(new QuestJogador(novoLocal.QuestDisponivel));
                }
            }

            // O local tem um monstro?
            if (novoLocal.MonstroPresente != null)
            {
                rtbMensagens.Text += "Você vê um " + novoLocal.MonstroPresente.Nome + Environment.NewLine;

                // Cria um novo monstro, usando os valores do monstro padrão na lista de Mundo.Monstro
                Monstro monstroPadrao = Mundo.MonstroPorID(novoLocal.MonstroPresente.ID);

                monstroAtual = new Monstro(monstroPadrao.SaudeAtual, monstroPadrao.SaudeMaxima, monstroPadrao.ID,
                    monstroPadrao.Nome, monstroPadrao.DanoMaximo, monstroPadrao.RecompensaXP, monstroPadrao.RecompensaOuro);

                foreach (ItemLoot itemLoot in monstroPadrao.TabelaLoot)
                {
                    monstroAtual.TabelaLoot.Add(itemLoot);
                }

                cboArmas.Visible = true;
                cboPocoes.Visible = true;
                btUsarArma.Visible = true;
                btUsarPocao.Visible = true;
            }
            else
            {
                monstroAtual = null;

                cboArmas.Visible = false;
                cboPocoes.Visible = false;
                btUsarArma.Visible = false;
                btUsarPocao.Visible = false;
            }

            // Atualiza a lista do inventário do jogador
            AtualizarInventarioInterface();

            // Atualiza a lista de quests do jogador
            AtualizarQuestsInterface();

            // Atualiza a combobox de armas do jogador
            AtualizarArmasInterface();

            // Atualiza a combobox de poções do jogador
            AtualizarPocoesInterface();

        }

        private void AtualizarInventarioInterface()
        {
            dgvInventario.RowHeadersVisible = false;

            dgvInventario.ColumnCount = 2;
            dgvInventario.Columns[0].Name = "Name";
            dgvInventario.Columns[0].Width = 197;
            dgvInventario.Columns[1].Name = "Quantity";

            dgvInventario.Rows.Clear();

            foreach (ItemInventario ItemInventario in jogador.Inventario)
            {
                if (ItemInventario.Quantidade > 0)
                {
                    dgvInventario.Rows.Add(new[] { ItemInventario.Detalhes.Nome, ItemInventario.Quantidade.ToString() });
                }
            }

        }

        private void AtualizarQuestsInterface()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Nome";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Feito?";

            dgvQuests.Rows.Clear();

            foreach (QuestJogador questJogador in jogador.Quests)
            {
                dgvQuests.Rows.Add(new[] { questJogador.Detalhes.Nome, questJogador.EstaCompleta.ToString() });
            }
        }

        private void AtualizarArmasInterface()
        {
            List<Arma> armas = new List<Arma>();

            foreach (ItemInventario itemInventario in jogador.Inventario)
            {
                if (itemInventario.Detalhes is Arma)
                {
                    if (itemInventario.Quantidade > 0)
                    {
                        armas.Add((Arma)itemInventario.Detalhes);
                    }
                }
            }

            if (armas.Count == 0)
            {
                // O jogador não tem armas, por isso esconder a combobox de armas e o botão de usar
                cboArmas.Visible = false;
                btUsarArma.Visible = false;
            }
            else
            {
                cboArmas.DataSource = armas;
                cboArmas.DisplayMember = "Nome";
                cboArmas.ValueMember = "ID";

                cboArmas.SelectedIndex = 0;
            }
        }

        private void AtualizarPocoesInterface()
        {
            List<Cura> pocoesCura = new List<Cura>();

            foreach (ItemInventario ItemInventario in jogador.Inventario)
            {
                if (ItemInventario.Detalhes is Cura)
                {
                    if (ItemInventario.Quantidade > 0)
                    {
                        pocoesCura.Add((Cura)ItemInventario.Detalhes);
                    }
                }
            }

            if (pocoesCura.Count == 0)
            {
                // O jogador não tem poções, por isso esconder a combobox e o botão de usar
                cboPocoes.Visible = false;
                btUsarPocao.Visible = false;
            }
            else
            {
                cboPocoes.DataSource = pocoesCura;
                cboPocoes.DisplayMember = "Nome";
                cboPocoes.ValueMember = "ID";

                cboPocoes.SelectedIndex = 0;
            }
        }

        private void MonstroAtacar()
        {
            // Determinar a quantidade de dano que o monstro dá no jogador
            int danoAoJogador = GeradorNumeros.NumeroEntre(0, monstroAtual.DanoMaximo);
            //Exibir mensagem
            rtbMensagens.Text += monstroAtual.Nome + " infligiu " + danoAoJogador.ToString() + " pontos de dano." + Environment.NewLine;
            // Subtrair dano do jogador
            jogador.SaudeAtual -= danoAoJogador;
            // Atualizar dados do jogador na interface
            lbl_saude.Text = jogador.SaudeAtual.ToString();
            if (jogador.SaudeAtual <= 0)
            {
                // Exibir mensagem
                rtbMensagens.Text += monstroAtual.Nome + " te matou!" + Environment.NewLine;
                // Mover jogador para casa
                MoverPara(Mundo.LocalPorID(Mundo.LOCAL_ID_CASA));
            }
        }

        private void btUsarArma_Click(object sender, EventArgs e)
        {
            // Obter a arma selecionada no combobox
            Arma armaAtual = (Arma)cboArmas.SelectedItem;
            // Determinar a quantidade de dano dado ao monstro
            int danoAoMonstro = GeradorNumeros.NumeroEntre(armaAtual.DanoMinimo, armaAtual.DanoMaximo);
            // Aplicar dano à saúde atual do monstro
            monstroAtual.SaudeAtual -= danoAoMonstro;
            // Exibir mensagem
            rtbMensagens.Text += "Você feriu " + monstroAtual.Nome + " por " + danoAoMonstro.ToString() + " pontos." + Environment.NewLine;

            // Checar se o monstro morreu
            if (monstroAtual.SaudeAtual <= 0)
            {
                // O monstro morreu
                rtbMensagens.Text += Environment.NewLine + "Você derrotou " + monstroAtual.Nome + Environment.NewLine;

                // Dar pontos de xp ao jogador
                jogador.PontosXP += monstroAtual.RecompensaXP;
                rtbMensagens.Text += "Você ganhou " + monstroAtual.RecompensaXP.ToString() + " pontos de experiência" + Environment.NewLine;

                // Dar dinheiro ao jogador
                jogador.Dinheiro += monstroAtual.RecompensaOuro;
                rtbMensagens.Text += "Você ganhou " + monstroAtual.RecompensaOuro.ToString() + " moedas de ouro" + Environment.NewLine;

                // Dar itens de loot aleatórios ao jogador
                List<ItemInventario> itensObtidos = new List<ItemInventario>();
                // Adicionar itens à lista de itens de loot, comparando um número aleatório à chance
                foreach(ItemLoot itemLoot in monstroAtual.TabelaLoot)
                {
                    if(GeradorNumeros.NumeroEntre(1,100) <= itemLoot.ChanceDrop)
                    {
                        itensObtidos.Add(new ItemInventario(itemLoot.Detalhes, 1));
                    }
                }
                // Adicionar os itens obtidos ao inventário do jogador
                foreach(ItemInventario itemInventario in itensObtidos)
                {
                    jogador.AdicionarItemAoInventario(itemInventario.Detalhes);
                    if(itemInventario.Quantidade == 1)
                    {
                        rtbMensagens.Text += "Voce obteve " + itemInventario.Quantidade.ToString() + " " + itemInventario.Detalhes.Nome + Environment.NewLine;
                    }
                    else
                    {
                        rtbMensagens.Text += "Voce obteve " + itemInventario.Quantidade.ToString() + " " + itemInventario.Detalhes.NomePlural + Environment.NewLine;
                    }
                }

                // Atualizar informação do jogador e controles
                lbl_saude.Text = jogador.SaudeAtual.ToString();
                lbl_dinheiro.Text = jogador.Dinheiro.ToString();
                lbl_exp.Text = jogador.PontosXP.ToString();
                lbl_nivel.Text = jogador.Nivel.ToString();
                AtualizarInventarioInterface();
                AtualizarArmasInterface();
                AtualizarPocoesInterface();

                // Linha em branco pra separar
                rtbMensagens.Text += Environment.NewLine;

                // Mover jogador para local atual (pra curar o jogador e criar novo monstro)
                MoverPara(jogador.LocalAtual);
            }
            else
            {
                // Monstro ainda vive
                MonstroAtacar();
            }
        }

        private void btUsarPocao_Click(object sender, EventArgs e)
        {
            // Obter a poção selecionada no combobox
            Cura pocao = (Cura)cboPocoes.SelectedItem;
            // Adicionar valor da cura à saúde do jogador
            jogador.SaudeAtual = (jogador.SaudeAtual + pocao.ValorCura);

            // Saúde atual não pode ser maior que saúde máxima
            if (jogador.SaudeAtual > jogador.SaudeMaxima)
            {
                jogador.SaudeAtual = jogador.SaudeMaxima;
            }

            // Remover poção do inventário do jogador
            foreach (ItemInventario ii in jogador.Inventario)
            {
                if (ii.Detalhes.ID == pocao.ID)
                {
                    ii.Quantidade--;
                    break;
                }
            }

            // Exibir mensagem
            rtbMensagens.Text += "Você bebeu " + pocao.Nome + Environment.NewLine;

            // Vez do monstro atacar
            MonstroAtacar();

            // Atualizar dados do jogador na interface
            lbl_saude.Text = jogador.SaudeAtual.ToString();
            AtualizarInventarioInterface();
            AtualizarPocoesInterface();
        }

    }
}
