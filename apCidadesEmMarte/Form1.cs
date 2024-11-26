// Ana Clara Martin da Silveira - 23122
// Sofia Tasselli Kawamura - 23157

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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

        Cidade cidadeSelecionada;
        Caminho caminhoSelecionado;

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

                int registroAtual = 0;
                int qtosRegistros = (int)origem.Length / new Caminho().TamanhoRegistro - 1;

                while (registroAtual <= qtosRegistros)
                {
                    Caminho novoCaminho = new Caminho();
                    novoCaminho.LerRegistro(arquivo, registroAtual);
                    registroAtual++;

                    Cidade cidadeOrigem = new Cidade(novoCaminho.CidadeOrigem, 0, 0);
                    if (arvore.Existe(cidadeOrigem))
                        arvore.Atual.Info.Caminhos.InserirAposFim(novoCaminho);
                }

                origem.Close();
                arquivo.Close();

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
            cidadeSelecionada = null;
            caminhoSelecionado = null;
        }

        private void LimparCamposCaminhos()
        {
            txtNomeCidadeDestino.Text = "";
            udCusto.Value = 0;
            udDistancia.Value = 0;
            udTempo.Value = 0;
            dgvCaminhos.Rows.Clear();
            caminhoSelecionado = null;
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            Cidade novaCidade = new Cidade(txtNomeCidade.Text, (double)udX.Value, (double)udY.Value);
            if (arvore.Existe(novaCidade))
                MessageBox.Show("Cidade já existente!");
            else
            {
                arvore.IncluirNovoRegistro(novaCidade);
                LimparCamposCaminhos();
                cidadeSelecionada = novaCidade;
                pbArvore.Invalidate();
                pbMapa.Invalidate();
            }
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (!arvore.ExcluirRecursivo(new Cidade(nome, 0, 0)))
                MessageBox.Show("Cidade não encontrada!");
            
            LimparCampos();
            pbArvore.Invalidate();
            pbMapa.Invalidate();
        }

        private void btnAlterarCidade_Click(object sender, EventArgs e)
        {
            String nome = txtNomeCidade.Text;
            if (arvore.Existe(new Cidade(nome, 0, 0)))
            {
                Cidade cidade = arvore.Atual.Info;

                cidade.X = (double)udX.Value;
                cidade.Y = (double)udY.Value;

                cidadeSelecionada = cidade;
                ExibirCaminhos();
                pbMapa.Invalidate();
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

                LimparCampos();
                
                udX.Value = (decimal)cidade.X;
                udY.Value = (decimal)cidade.Y;
                
                cidadeSelecionada = cidade;

                ExibirCaminhos();
                pbMapa.Invalidate();
            }
            else
            {
                MessageBox.Show("Cidade não encontrada!");
                LimparCampos();
            }
        }

        private void ExibirCaminhos()
        {
            dgvCaminhos.Rows.Clear();

            int indice = 0;
            var atual = cidadeSelecionada.Caminhos.Primeiro;

            while (atual != null)
            {
                var caminho = atual.Info;
                dgvCaminhos.Rows.Add(
                   caminho.CidadeDestino,
                   caminho.Distancia,
                   caminho.Tempo,
                   caminho.Custo
                );

                if (caminhoSelecionado != null && caminho.CidadeDestino == caminhoSelecionado.CidadeDestino)
                    dgvCaminhos.Rows[indice].DefaultCellStyle.BackColor = Color.Yellow;

                atual = atual.Prox;
                indice++;
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            ExibirCidadesMapa(arvore.Raiz, e.Graphics);
        }

        private void ExibirCidadesMapa(Arvore<Cidade>.NoArvore<Cidade> atual, Graphics ondeDesenhar)
        {
            if (atual != null)
            { 
                ExibirCidadesMapa(atual.Esq, ondeDesenhar);
                ExibirCidadesMapa(atual.Dir, ondeDesenhar);

                SolidBrush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(brush, 2);
                var fonte = new Font("Microsoft Sans Serif", 10);

                int x = (int)Math.Round(atual.Info.X * pbMapa.Width);
                int y = (int)Math.Round(atual.Info.Y * pbMapa.Height);

                ondeDesenhar.DrawString(atual.Info.Nome, fonte, brush, x, y);
                ondeDesenhar.DrawEllipse(pen, x, y, 3, 3);

                if (cidadeSelecionada != null)
                {
                    x = (int)Math.Round(cidadeSelecionada.X * pbMapa.Width);
                    y = (int)Math.Round(cidadeSelecionada.Y * pbMapa.Height);

                    var caminho = cidadeSelecionada.Caminhos.Primeiro;
                    while (caminho != null)
                    {
                        arvore.Existe(new Cidade(caminho.Info.CidadeDestino, 0, 0));
                        Cidade cidadeDestino = arvore.Atual.Info;

                        int x2 = (int)Math.Round(cidadeDestino.X * pbMapa.Width);
                        int y2 = (int)Math.Round(cidadeDestino.Y * pbMapa.Height);

                        ondeDesenhar.DrawLine(pen, x, y, x2, y2);

                        caminho = caminho.Prox;
                    }

                    brush = new SolidBrush(Color.Red);
                    pen = new Pen(brush, 2);

                    ondeDesenhar.DrawString(cidadeSelecionada.Nome, fonte, brush, x, y);
                    ondeDesenhar.DrawEllipse(pen, x, y, 3, 3);

                    if (caminhoSelecionado != null)
                    {
                        arvore.Existe(new Cidade(caminhoSelecionado.CidadeDestino, 0, 0));
                        Cidade cidadeDestino = arvore.Atual.Info;

                        int x2 = (int)Math.Round(cidadeDestino.X * pbMapa.Width);
                        int y2 = (int)Math.Round(cidadeDestino.Y * pbMapa.Height);

                        ondeDesenhar.DrawLine(pen, x, y, x2, y2);
                    }
                }
            }
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
                        cidadeSelecionada = cidade;
                        caminhoSelecionado = novoCaminho;
                        ExibirCaminhos();
                        pbMapa.Invalidate();
                    }
                }
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;
               
            Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);

            arvore.Existe(new Cidade(cidadeOrigem, 0, 0));
            Cidade cidade = arvore.Atual.Info;

            if (!cidade.Caminhos.Existe(novoCaminho))
                MessageBox.Show("Caminho não encontrado!");
            else
            {
                cidade.Caminhos.Excluir(novoCaminho);
                LimparCamposCaminhos();
                ExibirCaminhos();
            }
            
        }

        private void btnAlterarCaminho_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);

            arvore.Existe(new Cidade(cidadeOrigem, 0, 0));
            Cidade cidade = arvore.Atual.Info;

            if (!cidade.Caminhos.Existe(novoCaminho))
            {
                MessageBox.Show("Caminho não encontrado!");
                LimparCamposCaminhos();
            }
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
                        caminhoSelecionado = caminho;
                        break;
                    }

                    atual = atual.Prox;
                }
                ExibirCaminhos();
                pbMapa.Invalidate();
            }
            
        }

        private void btnExibirCaminhos_Click(object sender, EventArgs e)
        {
            String cidadeOrigem = txtNomeCidade.Text;
            String cidadeDestino = txtNomeCidadeDestino.Text;

            Caminho novoCaminho = new Caminho(cidadeOrigem, cidadeDestino, (int)udDistancia.Value, (int)udTempo.Value, (int)udCusto.Value);
            arvore.Existe(new Cidade(cidadeOrigem, 0, 0));

            Cidade cidade = arvore.Atual.Info;
            if (!cidade.Caminhos.Existe(novoCaminho))
            {
                MessageBox.Show("Caminho não encontrado!");
            }
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

                        caminhoSelecionado = caminho;

                        ExibirCaminhos();
                        pbMapa.Invalidate();

                        break;
                    }

                    atual = atual.Prox;
                };
            }
        }

        private void FrmCidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            // salvar arquivo de cidades
            arvore.GravarArquivoDeRegistros(nomeArquivoCidades);

            // salvar arquivo de caminhos
            var destino = new FileStream(nomeArquivoCaminhos, FileMode.Create);
            var arquivo = new BinaryWriter(destino);
            SalvarArquivoCaminhos(arvore.Raiz, arquivo);
            destino.Close();
            arquivo.Close();
        }

        private void SalvarArquivoCaminhos(Arvore<Cidade>.NoArvore<Cidade> atual, BinaryWriter arquivo)
        {
            if (atual != null)
            {
                SalvarArquivoCaminhos(atual.Esq, arquivo);
                SalvarArquivoCaminhos(atual.Dir, arquivo);

                ListaSimples<Caminho> caminhos = atual.Info.Caminhos;
                var caminho = caminhos.Primeiro;
                while (caminho != null)
                {
                    caminho.Info.GravarRegistro(arquivo);
                    caminho = caminho.Prox;
                }
            }
        }
    }
}
