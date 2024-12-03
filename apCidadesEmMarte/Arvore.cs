// Ana Clara Martin da Silveira - 23122
// Sofia Tasselli Kawamura - 23157

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Arvore<Dado> where Dado : IComparable<Dado>, IRegistro, new()
{
    public class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>, IRegistro, new()
    {
        Dado info;
        public NoArvore<Dado> esq, dir;

        public NoArvore()
        {
            info = default(Dado);
            esq = dir = null;
        }

        public NoArvore(Dado informacao)
        {
            info = informacao;
            esq = dir = null;
        }

        public NoArvore(Dado informacao, NoArvore<Dado> e, NoArvore<Dado> d)
        {
            info = informacao;
            esq = e;
            dir = d;
        }

        public Dado Info
        { 
            get => info; 
            set => info = value; 
        }

        public NoArvore<Dado> Esq
        { 
            get => esq; 
            set => esq = value; 
        }

        public NoArvore<Dado> Dir
        { 
            get => dir; 
            set => dir = value; 
        }

        public int CompareTo(NoArvore<Dado> outro)
        {
            if (outro != null)
                return this.info.CompareTo(outro.info);

            return -1;
        }

        public bool Equals(NoArvore<Dado> outro)
        {
            return this.info.Equals(outro.info);
        }
    }

    // classe árvore
    NoArvore<Dado> raiz, atual, antecessor;
    int qtosNos;

    public Arvore()
    {
        raiz = null;
        atual = null;
        antecessor = null;
        qtosNos = 0;
    }

    public NoArvore<Dado> Raiz
    {
        get => raiz;
        set => raiz = value;
    }

    public NoArvore<Dado> Atual { get => atual; set => atual = value; }

    public NoArvore<Dado> Anterior { get => antecessor; set => antecessor = value; }

    public void DesenharArvore(int x, int y, Graphics g)
    {
        DesenharArvore(true, this.raiz, x, y, Math.PI / 2, 1, 200, g);
    }

    private void DesenharArvore(bool primeiraVez, NoArvore<Dado> noAtual,
                                   int x, int y, double angulo, double incremento,
                                   double comprimento, Graphics g)
    {
        int xf, yf;

        if (noAtual != null)
        {
            Pen caneta = new Pen(Color.DeepPink);

            xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
            yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);

            if (primeiraVez)
                yf = 25;

            g.DrawLine(caneta, x, y, xf, yf);

            DesenharArvore(false, noAtual.Esq, xf, yf, Math.PI / 2 + incremento,
                           incremento * 0.60, comprimento * 0.8, g);
            DesenharArvore(false, noAtual.Dir, xf, yf, Math.PI / 2 - incremento,
                           incremento * 0.60, comprimento * 0.8, g);

            SolidBrush preenchimento = new SolidBrush(Color.DeepPink);
            g.FillEllipse(preenchimento, xf-35, yf-15, 70, 30);

            Font fonte = new Font("Comic-Sans", 8);
            SizeF tamanho = g.MeasureString(noAtual.Info.ToString(), fonte);

            float xTexto = xf - (tamanho.Width / 2);
            float yTexto = yf - (tamanho.Height / 2);

            g.DrawString(noAtual.Info.ToString(), fonte, new SolidBrush(Color.White), xTexto, yTexto);
        }
    }

    public void LerArquivoDeRegistros(string nomeArquivo)
    {
        raiz = null;
        Dado dado = new Dado();

        var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
        var arquivo = new BinaryReader(origem);

        int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
        Particionar(0, posicaoFinal, ref raiz);
        origem.Close();
      
        void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
        {
            if (inicio <= fim)
            {
                long meio = (inicio + fim) / 2;
                dado = new Dado();
                dado.LerRegistro(arquivo, meio);
                atual = new NoArvore<Dado>(dado);
                Particionar(inicio, meio - 1, ref atual.esq);
                var novoDir = atual.Dir;
                Particionar(meio + 1, fim, ref atual.dir); 
            }
        }
    }

    public void GravarArquivoDeRegistros(string nomeArquivo)
    {
        var destino = new FileStream(nomeArquivo, FileMode.Create);
        var arquivo = new BinaryWriter(destino);
        GravarInOrdem(raiz);
        arquivo.Close();

        void GravarInOrdem(NoArvore<Dado> r)
        {
            if (r != null)
            {
                GravarInOrdem(r.Esq);
                r.Info.GravarRegistro(arquivo);
                GravarInOrdem(r.Dir);
            }
        }
    }

    public void GravarArquivoJson(string nomeArquivo)
    {
        var destino = new FileStream(nomeArquivo, FileMode.Create);
        var arquivo = new StreamWriter(destino);
        arquivo.Write("[\n");
        GravarInOrdem(raiz);
        arquivo.Write("]");
        arquivo.Close();

        void GravarInOrdem(NoArvore<Dado> r)
        {
            if (r != null)
            {
                GravarInOrdem(r.Esq);
                r.Info.GravarJSON(arquivo);
                GravarInOrdem(r.Dir);
            }
        }
    }

    public bool Existe(Dado procurado)
    {
        antecessor = null;
        atual = raiz;
        while (atual != null)
        {
            if (atual.Info.CompareTo(procurado) == 0)
                return true;

            antecessor = atual;
            if (procurado.CompareTo(atual.Info) < 0)
                atual = atual.esq;
            else
                atual = atual.dir;
        }
        return false;
    }

    // inclusão não-recursiva aproveitando o método Existe já codificado
    public void IncluirNovoRegistro(Dado novoRegistro)
    {
        if (Existe(novoRegistro))
            throw new Exception("Registro com chave repetida!");

        var novoNo = new NoArvore<Dado>(novoRegistro);
        if (raiz == null)
            raiz = novoNo;
        else
        {
            if (novoRegistro.CompareTo(antecessor.Info) < 0)
                antecessor.Esq = novoNo;
            else
                antecessor.Dir = novoNo;
        }
    }

    public bool ExcluirRecursivo(Dado procurado)
    {
        return ExcluirInterno(ref raiz);

        bool ExcluirInterno(ref NoArvore<Dado> atual)
        {
            NoArvore<Dado> atualAnt;
            if (atual == null)
                return false;
            else
            {
                if (atual.Info.CompareTo(procurado) > 0)
                {
                    var temp = atual.Esq;
                    bool result = ExcluirInterno(ref temp);
                    atual.Esq = temp;
                    return result;
                }
                else
                {
                    if (atual.Info.CompareTo(procurado) < 0)
                    {
                        var temp = atual.Dir;
                        bool result = ExcluirInterno(ref temp);
                        atual.Dir = temp;
                        return result;
                    }
                    else
                    {
                        atualAnt = atual;
                        if (atual.Dir == null)
                            atual = atual.Esq;
                        else
                        {
                            if (atual.Esq == null)
                                atual = atual.Dir;
                            else
                            { 
                                var temp = atual.Esq;
                                Rearranjar(ref temp, ref atualAnt);
                                atual.Esq = temp;
                                atualAnt = null;
                            }
                        }
                        return true;
                    }
                }
            }
        }

        void Rearranjar(ref NoArvore<Dado> aux, ref NoArvore<Dado> atualAnt)
        {
            if (aux.Dir != null)
            {
                NoArvore<Dado> temp = aux.Dir;
                Rearranjar(ref temp, ref atualAnt);
                aux.Dir = temp;
            }
            else
            {
                atualAnt.Info = aux.Info;
                atualAnt = aux;
                aux = aux.Esq;
            }
        }
    }
}