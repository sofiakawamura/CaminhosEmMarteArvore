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

                var origem = new FileStream(nomeArquivoCaminhos, FileMode.OpenOrCreate);
                var arquivo = new BinaryReader(origem);

                int posicaoAtual = 0;
                int posicaoFinal = (int)origem.Length / new Caminho().TamanhoRegistro - 1;

                while (posicaoAtual < posicaoFinal)
                {
                    Caminho novoCaminho = new Caminho();
                    novoCaminho.LerRegistro(arquivo, posicaoAtual);
                    posicaoAtual += novoCaminho.TamanhoRegistro;

                    Cidade cidadeOrigem = new Cidade(novoCaminho.CidadeOrigem, 0, 0);
                    if (arvore.Existe(cidadeOrigem))
                    {
                        arvore.Atual.Info.Caminhos.InserirAposFim(novoCaminho);
                    }
                }

                dgvCaminhos.Columns.Clear();

                dgvCaminhos.Columns.Add("CidadeDestino", "Cidade Destino");
                dgvCaminhos.Columns.Add("Distancia", "Distância");
                dgvCaminhos.Columns.Add("Tempo", "Tempo");
                dgvCaminhos.Columns.Add("Custo", "Custo");
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
            txtNomeCidadeDestino.Text = "";
            udCusto.Value = 0;
            udDistancia.Value = 0;
            udTempo.Value = 0;
            dgvCaminhos.Rows.Clear();
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            Cidade novaCidade = new Cidade(txtNomeCidade.Text, (double)udX.Value, (double)udY.Value);
            if (arvore.Existe(novaCidade))
                MessageBox.Show("Cidade já existente!");
            else
            {
                arvore.IncluirNovoRegistro(novaCidade);
                pbArvore.Invalidate();
            }
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (!arvore.ExcluirRecursivo(new Cidade(nome, 0, 0)))
                MessageBox.Show("Cidade não encontrada!");
            
            LimparCampos();
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
                ExibirCaminhos(cidade, "");

                // exibir no mapa
            }
            else
            {
                MessageBox.Show("Cidade não encontrada!");
                LimparCampos();
            }
        }

        private void ExibirCaminhos(Cidade cidade, String cidadeDestinoDestacada)
        {
            dgvCaminhos.Rows.Clear();

            int indice = 0;
            var atual = cidade.Caminhos.Primeiro;

            while (atual != null)
            {
                var caminho = atual.Info;
                dgvCaminhos.Rows.Add(
                   caminho.CidadeDestino,
                   caminho.Distancia,
                   caminho.Tempo,
                   caminho.Custo
               );

                if (caminho.CidadeDestino == cidadeDestinoDestacada)
                    dgvCaminhos.Rows[indice].DefaultCellStyle.BackColor = Color.Yellow;

                atual = atual.Prox;
                indice++;
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            // percorrer árvore e, para cada nó, exibir a cidade no mapa

        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            if (cidadeDestino == "" || !arvore.Existe(new Cidade(cidadeDestino, 0, 0)))
                MessageBox.Show("Cidade de destino não encontrada!");
            else
            {
                if (cidadeOrigem == "" || !arvore.Existe(new Cidade(cidadeOrigem, 0, 0)))
                    MessageBox.Show("Cidade de origem não encontrada!");
                else
                {
                    Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);
                    Cidade cidade = arvore.Atual.Info;
                    if (cidade.Caminhos.Existe(novoCaminho))
                        MessageBox.Show("Caminho já existente!");
                    else
                    { 
                        cidade.Caminhos.InserirAposFim(novoCaminho);
                        ExibirCaminhos(cidade, "");
                    }
                }
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            if (cidadeOrigem == "" || !arvore.Existe(new Cidade(cidadeOrigem, 0, 0)))
                MessageBox.Show("Cidade de origem não encontrada!");
            else
            {
                Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);
                Cidade cidade = arvore.Atual.Info;
                if (!cidade.Caminhos.Existe(novoCaminho))
                    MessageBox.Show("Caminho não encontrado!");
                else
                {
                    cidade.Caminhos.Excluir(novoCaminho);
                    ExibirCaminhos(cidade, "");
                }
            }
        }

        private void btnAlterarCaminho_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);
            Cidade cidade = arvore.Atual.Info;
            if (!cidade.Caminhos.Existe(novoCaminho))
                MessageBox.Show("Caminho não encontrado!");
            else
            {
                var atual = cidade.Caminhos.Primeiro;
                while (atual != null)
                {
                    var caminho = atual.Info;
                    if (caminho.CompareTo(novoCaminho) == 0)
                    {
                        caminho.Tempo = (int)udTempo.Value;
                        caminho.Distancia = (int)udDistancia.Value;
                        caminho.Custo = (int)udCusto.Value;
                        break;
                    }

                    atual = atual.Prox;
                }
                ExibirCaminhos(cidade, "");
            }
            
        }

        private void btnExibirCaminhos_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);
            Cidade cidade = arvore.Atual.Info;
            if (!cidade.Caminhos.Existe(novoCaminho))
                MessageBox.Show("Caminho não encontrado!");
            else
            {
                var atual = cidade.Caminhos.Primeiro;
                while (atual != null)
                {
                    var caminho = atual.Info;
                    if (caminho.CompareTo(novoCaminho) == 0)
                    {
                        udTempo.Value = caminho.Tempo;
                        udCusto.Value = caminho.Custo;
                        udDistancia.Value = caminho.Distancia;

                        ExibirCaminhos(cidade, caminho.CidadeDestino);

                        // exibir no mapa

                        break;
                    }

                    atual = atual.Prox;
                };
            }
        }

        private void FrmCidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            arvore.GravarArquivoDeRegistros(nomeArquivoCidades);

        }
    }
}
