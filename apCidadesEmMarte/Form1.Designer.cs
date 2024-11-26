namespace apCidadesEmMarte
{
    partial class FrmCidades
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCidades = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExibirCaminhos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAlterarCaminho = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.udDistancia = new System.Windows.Forms.NumericUpDown();
            this.udCusto = new System.Windows.Forms.NumericUpDown();
            this.udTempo = new System.Windows.Forms.NumericUpDown();
            this.txtNomeCidadeDestino = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIncluirCidade = new System.Windows.Forms.Button();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.btnExibirCidade = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlterarCidade = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.udX = new System.Windows.Forms.NumericUpDown();
            this.btnExcluirCidade = new System.Windows.Forms.Button();
            this.udY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.pbArvore = new System.Windows.Forms.PictureBox();
            this.dlgCidades = new System.Windows.Forms.OpenFileDialog();
            this.dlgCamimnhos = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tpCidades.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tpArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCidades);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1023, 580);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCidades
            // 
            this.tpCidades.Controls.Add(this.groupBox2);
            this.tpCidades.Controls.Add(this.dgvCaminhos);
            this.tpCidades.Controls.Add(this.groupBox1);
            this.tpCidades.Controls.Add(this.pbMapa);
            this.tpCidades.Location = new System.Drawing.Point(4, 29);
            this.tpCidades.Name = "tpCidades";
            this.tpCidades.Padding = new System.Windows.Forms.Padding(3);
            this.tpCidades.Size = new System.Drawing.Size(1015, 547);
            this.tpCidades.TabIndex = 0;
            this.tpCidades.Text = "Cadastro";
            this.tpCidades.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnExibirCaminhos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnExcluirCaminho);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnAlterarCaminho);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnIncluirCaminho);
            this.groupBox2.Controls.Add(this.udDistancia);
            this.groupBox2.Controls.Add(this.udCusto);
            this.groupBox2.Controls.Add(this.udTempo);
            this.groupBox2.Controls.Add(this.txtNomeCidadeDestino);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(581, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 218);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label9.Location = new System.Drawing.Point(18, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 26);
            this.label9.TabIndex = 23;
            this.label9.Text = "Caminhos";
            // 
            // btnExibirCaminhos
            // 
            this.btnExibirCaminhos.Location = new System.Drawing.Point(266, 174);
            this.btnExibirCaminhos.Name = "btnExibirCaminhos";
            this.btnExibirCaminhos.Size = new System.Drawing.Size(75, 25);
            this.btnExibirCaminhos.TabIndex = 26;
            this.btnExibirCaminhos.Text = "Exibir";
            this.btnExibirCaminhos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Distância:";
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.Location = new System.Drawing.Point(103, 174);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(75, 25);
            this.btnExcluirCaminho.TabIndex = 4;
            this.btnExcluirCaminho.Text = "Excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Cidade de Destino:";
            // 
            // btnAlterarCaminho
            // 
            this.btnAlterarCaminho.Location = new System.Drawing.Point(184, 174);
            this.btnAlterarCaminho.Name = "btnAlterarCaminho";
            this.btnAlterarCaminho.Size = new System.Drawing.Size(75, 25);
            this.btnAlterarCaminho.TabIndex = 3;
            this.btnAlterarCaminho.Text = "Alterar";
            this.btnAlterarCaminho.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tempo:";
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Location = new System.Drawing.Point(22, 174);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(75, 25);
            this.btnIncluirCaminho.TabIndex = 2;
            this.btnIncluirCaminho.Text = "Incluir";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            // 
            // udDistancia
            // 
            this.udDistancia.Location = new System.Drawing.Point(22, 133);
            this.udDistancia.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udDistancia.Name = "udDistancia";
            this.udDistancia.Size = new System.Drawing.Size(120, 26);
            this.udDistancia.TabIndex = 23;
            // 
            // udCusto
            // 
            this.udCusto.Location = new System.Drawing.Point(273, 133);
            this.udCusto.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udCusto.Name = "udCusto";
            this.udCusto.Size = new System.Drawing.Size(120, 26);
            this.udCusto.TabIndex = 25;
            // 
            // udTempo
            // 
            this.udTempo.Location = new System.Drawing.Point(148, 133);
            this.udTempo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.udTempo.Name = "udTempo";
            this.udTempo.Size = new System.Drawing.Size(120, 26);
            this.udTempo.TabIndex = 24;
            // 
            // txtNomeCidadeDestino
            // 
            this.txtNomeCidadeDestino.Location = new System.Drawing.Point(22, 80);
            this.txtNomeCidadeDestino.MaxLength = 15;
            this.txtNomeCidadeDestino.Name = "txtNomeCidadeDestino";
            this.txtNomeCidadeDestino.Size = new System.Drawing.Size(234, 26);
            this.txtNomeCidadeDestino.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Custo:";
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.AllowUserToAddRows = false;
            this.dgvCaminhos.AllowUserToDeleteRows = false;
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(581, 231);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.ReadOnly = true;
            this.dgvCaminhos.RowHeadersWidth = 51;
            this.dgvCaminhos.Size = new System.Drawing.Size(406, 287);
            this.dgvCaminhos.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnIncluirCidade);
            this.groupBox1.Controls.Add(this.txtNomeCidade);
            this.groupBox1.Controls.Add(this.btnExibirCidade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAlterarCidade);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.udX);
            this.groupBox1.Controls.Add(this.btnExcluirCidade);
            this.groupBox1.Controls.Add(this.udY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 160);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(15, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 26);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cidade";
            // 
            // btnIncluirCidade
            // 
            this.btnIncluirCidade.Location = new System.Drawing.Point(19, 115);
            this.btnIncluirCidade.Name = "btnIncluirCidade";
            this.btnIncluirCidade.Size = new System.Drawing.Size(75, 25);
            this.btnIncluirCidade.TabIndex = 10;
            this.btnIncluirCidade.Text = "Incluir";
            this.btnIncluirCidade.UseVisualStyleBackColor = true;
            this.btnIncluirCidade.Click += new System.EventHandler(this.btnIncluirCidade_Click);
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.Location = new System.Drawing.Point(19, 80);
            this.txtNomeCidade.MaxLength = 15;
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(234, 26);
            this.txtNomeCidade.TabIndex = 14;
            // 
            // btnExibirCidade
            // 
            this.btnExibirCidade.Location = new System.Drawing.Point(263, 115);
            this.btnExibirCidade.Name = "btnExibirCidade";
            this.btnExibirCidade.Size = new System.Drawing.Size(75, 25);
            this.btnExibirCidade.TabIndex = 11;
            this.btnExibirCidade.Text = "Exibir";
            this.btnExibirCidade.UseVisualStyleBackColor = true;
            this.btnExibirCidade.Click += new System.EventHandler(this.btnExibirCidade_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nome";
            // 
            // btnAlterarCidade
            // 
            this.btnAlterarCidade.Location = new System.Drawing.Point(181, 115);
            this.btnAlterarCidade.Name = "btnAlterarCidade";
            this.btnAlterarCidade.Size = new System.Drawing.Size(75, 25);
            this.btnAlterarCidade.TabIndex = 12;
            this.btnAlterarCidade.Text = "Alterar";
            this.btnAlterarCidade.UseVisualStyleBackColor = true;
            this.btnAlterarCidade.Click += new System.EventHandler(this.btnAlterarCidade_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "X";
            // 
            // udX
            // 
            this.udX.DecimalPlaces = 5;
            this.udX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.udX.Location = new System.Drawing.Point(271, 80);
            this.udX.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udX.Name = "udX";
            this.udX.Size = new System.Drawing.Size(67, 26);
            this.udX.TabIndex = 15;
            // 
            // btnExcluirCidade
            // 
            this.btnExcluirCidade.Location = new System.Drawing.Point(100, 115);
            this.btnExcluirCidade.Name = "btnExcluirCidade";
            this.btnExcluirCidade.Size = new System.Drawing.Size(75, 25);
            this.btnExcluirCidade.TabIndex = 13;
            this.btnExcluirCidade.Text = "Excluir";
            this.btnExcluirCidade.UseVisualStyleBackColor = true;
            this.btnExcluirCidade.Click += new System.EventHandler(this.btnExcluirCidade_Click);
            // 
            // udY
            // 
            this.udY.DecimalPlaces = 5;
            this.udY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.udY.Location = new System.Drawing.Point(353, 80);
            this.udY.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udY.Name = "udY";
            this.udY.Size = new System.Drawing.Size(65, 26);
            this.udY.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y";
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = global::apCidadesEmMarte.Properties.Resources.Mapa_Marte_sem_rotas;
            this.pbMapa.Location = new System.Drawing.Point(30, 173);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(520, 344);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // tpArvore
            // 
            this.tpArvore.Controls.Add(this.pbArvore);
            this.tpArvore.Location = new System.Drawing.Point(4, 25);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1015, 551);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore";
            this.tpArvore.UseVisualStyleBackColor = true;
            // 
            // pbArvore
            // 
            this.pbArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbArvore.Location = new System.Drawing.Point(7, 6);
            this.pbArvore.Name = "pbArvore";
            this.pbArvore.Size = new System.Drawing.Size(1002, 535);
            this.pbArvore.TabIndex = 0;
            this.pbArvore.TabStop = false;
            this.pbArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pbArvore_Paint);
            // 
            // dlgCidades
            // 
            this.dlgCidades.FileName = "openFileDialog1";
            this.dlgCidades.Title = "Arquivo de cidades";
            // 
            // dlgCamimnhos
            // 
            this.dlgCamimnhos.FileName = "openFileDialog1";
            this.dlgCamimnhos.Title = "Arquivo de caminhos";
            // 
            // FrmCidades
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1026, 586);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "FrmCidades";
            this.Text = "Manutenção de cidades em Marte";
            this.Load += new System.EventHandler(this.FrmCidades_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCidades.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tpArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCidades;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.NumericUpDown udY;
        private System.Windows.Forms.NumericUpDown udX;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.Button btnExcluirCidade;
        private System.Windows.Forms.Button btnAlterarCidade;
        private System.Windows.Forms.Button btnExibirCidade;
        private System.Windows.Forms.Button btnIncluirCidade;
        private System.Windows.Forms.Button btnExcluirCaminho;
        private System.Windows.Forms.Button btnAlterarCaminho;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExibirCaminhos;
        private System.Windows.Forms.NumericUpDown udCusto;
        private System.Windows.Forms.TextBox txtNomeCidadeDestino;
        private System.Windows.Forms.NumericUpDown udTempo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown udDistancia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog dlgCidades;
        private System.Windows.Forms.PictureBox pbArvore;
        private System.Windows.Forms.OpenFileDialog dlgCamimnhos;
    }
}

