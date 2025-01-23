namespace MegaAventura
{
    partial class MegaAventura
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lbl_saude = new Label();
            lbl_dinheiro = new Label();
            lbl_exp = new Label();
            lbl_nivel = new Label();
            label5 = new Label();
            cboArmas = new ComboBox();
            cboPocoes = new ComboBox();
            btUsarArma = new Button();
            btUsarPocao = new Button();
            btNorte = new Button();
            btSul = new Button();
            btLeste = new Button();
            btOeste = new Button();
            rtbLocal = new RichTextBox();
            rtbMensagens = new RichTextBox();
            dgvInventario = new DataGridView();
            dgvQuests = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Saúde: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 33);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Dinheiro: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 57);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Experiência:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 81);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 3;
            label4.Text = "Nível:";
            // 
            // lbl_saude
            // 
            lbl_saude.AutoSize = true;
            lbl_saude.Location = new Point(101, 9);
            lbl_saude.Name = "lbl_saude";
            lbl_saude.Size = new Size(0, 15);
            lbl_saude.TabIndex = 4;
            // 
            // lbl_dinheiro
            // 
            lbl_dinheiro.AutoSize = true;
            lbl_dinheiro.Location = new Point(101, 33);
            lbl_dinheiro.Name = "lbl_dinheiro";
            lbl_dinheiro.Size = new Size(0, 15);
            lbl_dinheiro.TabIndex = 5;
            // 
            // lbl_exp
            // 
            lbl_exp.AutoSize = true;
            lbl_exp.Location = new Point(101, 57);
            lbl_exp.Name = "lbl_exp";
            lbl_exp.Size = new Size(0, 15);
            lbl_exp.TabIndex = 6;
            // 
            // lbl_nivel
            // 
            lbl_nivel.AutoSize = true;
            lbl_nivel.Location = new Point(101, 81);
            lbl_nivel.Name = "lbl_nivel";
            lbl_nivel.Size = new Size(0, 15);
            lbl_nivel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(578, 519);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 8;
            label5.Text = "Selecionar ação: ";
            // 
            // cboArmas
            // 
            cboArmas.FormattingEnabled = true;
            cboArmas.Location = new Point(401, 545);
            cboArmas.Name = "cboArmas";
            cboArmas.Size = new Size(121, 23);
            cboArmas.TabIndex = 9;
            // 
            // cboPocoes
            // 
            cboPocoes.FormattingEnabled = true;
            cboPocoes.Location = new Point(401, 575);
            cboPocoes.Name = "cboPocoes";
            cboPocoes.Size = new Size(121, 23);
            cboPocoes.TabIndex = 10;
            // 
            // btUsarArma
            // 
            btUsarArma.Location = new Point(578, 545);
            btUsarArma.Name = "btUsarArma";
            btUsarArma.Size = new Size(75, 23);
            btUsarArma.TabIndex = 11;
            btUsarArma.Text = "Usar";
            btUsarArma.UseVisualStyleBackColor = true;
            btUsarArma.Click += btUsarArma_Click;
            // 
            // btUsarPocao
            // 
            btUsarPocao.Location = new Point(578, 574);
            btUsarPocao.Name = "btUsarPocao";
            btUsarPocao.Size = new Size(75, 23);
            btUsarPocao.TabIndex = 12;
            btUsarPocao.Text = "Usar";
            btUsarPocao.UseVisualStyleBackColor = true;
            btUsarPocao.Click += btUsarPocao_Click;
            // 
            // btNorte
            // 
            btNorte.Location = new Point(497, 418);
            btNorte.Name = "btNorte";
            btNorte.Size = new Size(75, 23);
            btNorte.TabIndex = 13;
            btNorte.Text = "Norte";
            btNorte.UseVisualStyleBackColor = true;
            btNorte.Click += btNorte_Click;
            // 
            // btSul
            // 
            btSul.Location = new Point(497, 459);
            btSul.Name = "btSul";
            btSul.Size = new Size(75, 23);
            btSul.TabIndex = 14;
            btSul.Text = "Sul";
            btSul.UseVisualStyleBackColor = true;
            btSul.Click += btSul_Click;
            // 
            // btLeste
            // 
            btLeste.Location = new Point(578, 439);
            btLeste.Name = "btLeste";
            btLeste.Size = new Size(75, 23);
            btLeste.TabIndex = 15;
            btLeste.Text = "Leste";
            btLeste.UseVisualStyleBackColor = true;
            btLeste.Click += btLeste_Click;
            // 
            // btOeste
            // 
            btOeste.Location = new Point(416, 439);
            btOeste.Name = "btOeste";
            btOeste.Size = new Size(75, 23);
            btOeste.TabIndex = 16;
            btOeste.Text = "Oeste";
            btOeste.UseVisualStyleBackColor = true;
            btOeste.Click += btOeste_Click;
            // 
            // rtbLocal
            // 
            rtbLocal.Location = new Point(347, 12);
            rtbLocal.Name = "rtbLocal";
            rtbLocal.ReadOnly = true;
            rtbLocal.Size = new Size(360, 105);
            rtbLocal.TabIndex = 17;
            rtbLocal.Text = "";
            // 
            // rtbMensagens
            // 
            rtbMensagens.Location = new Point(347, 123);
            rtbMensagens.Name = "rtbMensagens";
            rtbMensagens.ReadOnly = true;
            rtbMensagens.Size = new Size(360, 286);
            rtbMensagens.TabIndex = 18;
            rtbMensagens.Text = "";
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.AllowUserToResizeRows = false;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInventario.Enabled = false;
            dgvInventario.Location = new Point(13, 123);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.Size = new Size(312, 309);
            dgvInventario.TabIndex = 19;
            // 
            // dgvQuests
            // 
            dgvQuests.AllowUserToAddRows = false;
            dgvQuests.AllowUserToDeleteRows = false;
            dgvQuests.AllowUserToResizeRows = false;
            dgvQuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuests.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvQuests.Enabled = false;
            dgvQuests.Location = new Point(12, 439);
            dgvQuests.MultiSelect = false;
            dgvQuests.Name = "dgvQuests";
            dgvQuests.ReadOnly = true;
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.Size = new Size(312, 189);
            dgvQuests.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 651);
            Controls.Add(dgvQuests);
            Controls.Add(dgvInventario);
            Controls.Add(rtbMensagens);
            Controls.Add(rtbLocal);
            Controls.Add(btOeste);
            Controls.Add(btLeste);
            Controls.Add(btSul);
            Controls.Add(btNorte);
            Controls.Add(btUsarPocao);
            Controls.Add(btUsarArma);
            Controls.Add(cboPocoes);
            Controls.Add(cboArmas);
            Controls.Add(label5);
            Controls.Add(lbl_nivel);
            Controls.Add(lbl_exp);
            Controls.Add(lbl_dinheiro);
            Controls.Add(lbl_saude);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Jogo";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbl_saude;
        private Label lbl_dinheiro;
        private Label lbl_exp;
        private Label lbl_nivel;
        private Label label5;
        private ComboBox cboArmas;
        private ComboBox cboPocoes;
        private Button btUsarArma;
        private Button btUsarPocao;
        private Button btNorte;
        private Button btSul;
        private Button btLeste;
        private Button btOeste;
        private RichTextBox rtbLocal;
        private RichTextBox rtbMensagens;
        private DataGridView dgvInventario;
        private DataGridView dgvQuests;
    }
}
