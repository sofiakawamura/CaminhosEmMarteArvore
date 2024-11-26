using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCidadesEmMarte
{
    public partial class FrmCidades : Form
    {
        public FrmCidades()
        {
            InitializeComponent();
        }
        Arvore<Cidade> arvore;

        string nomeArquivoCidades;
        string nomeArquivoCaminhos;

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            arvore = new Arvore<Cidade>();

            if (dlgCidades.ShowDialog() == DialogResult.OK)
            {
                nomeArquivoCidades = dlgCidades.FileName;
                arvore.LerArquivoDeRegistros(nomeArquivoCidades);
                pbArvore.Invalidate();
            }

            if (dlgCamimnhos.ShowDialog() == DialogResult.OK)
            {
                nomeArquivoCaminhos = dlgCamimnhos.FileName;

                // ler arquivo de caminhos e colocar em cada cidade
            }
        }

        private void pbArvore_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            arvore.DesenharArvore(pbArvore.Width / 2, 0, e.Graphics);
        }

        private void LimparCampos()
        {
            udX.Value = 0;
            udY.Value = 0;
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            Cidade novaCidade = new Cidade(txtNomeCidade.Text, (double)udX.Value, (double)udY.Value);
            arvore.IncluirNovoRegistro(novaCidade);
            pbArvore.Invalidate();
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (!arvore.ExcluirRecursivo(new Cidade(nome, 0, 0)))
            {
                MessageBox.Show("Cidade não encontrada!");
                LimparCampos();
            }
            pbArvore.Invalidate();
        }

        private void btnAlterarCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (arvore.Existe(new Cidade(nome, 0, 0)))
            {
                Cidade cidade = arvore.Atual.Info;

                cidade.X = (double)udX.Value;
                cidade.Y = (double)udY.Value;
            }
            else
            {
                MessageBox.Show("Cidade não encontrada!");
                LimparCampos();
            }
        }

        private void btnExibirCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (arvore.Existe(new Cidade(nome, 0, 0)))
            {
                Cidade cidade = arvore.Atual.Info;

                udX.Value = (decimal)cidade.X;
                udY.Value = (decimal)cidade.Y;

                // exibir caminhos

                // exibir no mapa
            }
            else
            {
                MessageBox.Show("Cidade não encontrada!");
                LimparCampos();
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            // percorrer árvore e, para cada nó, exibir a cidade
        }
    }
}
