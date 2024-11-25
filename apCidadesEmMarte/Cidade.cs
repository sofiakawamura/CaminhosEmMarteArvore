// Ana Clara Martin da Silveira - 23122
// Sofia Tasselli Kawamura - 23157

using System;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Windows.Forms;

public class Cidade : IComparable<Cidade>, IRegistro
{
    public const int tamanhoNome = 15;
    string nome;
    double x, y;
    ListaSimples<Caminho> caminhos;

    public string Nome
    {
        get => this.nome;
        set
        {
            this.nome = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }
    }

    public double X => this.x;

    public double Y => this.y;

    public ListaSimples<Caminho> Caminhos => this.caminhos;

    public const int tamanhoRegistro = tamanhoNome + sizeof(double) + sizeof(double);

    public int TamanhoRegistro => tamanhoRegistro;

    public Cidade() { }

    public Cidade(string nome, double x, double y, ListaSimples<Caminho> caminhos)
    {
        this.Nome = nome;
        this.x = x;
        this.y = y;
        this.caminhos = caminhos;
    }

    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        if (arquivo != null)
        {
            try
            {
                long qtosBytes = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);

                // lendo nome da cidade de origem
                char[] nomeChar = new char[tamanhoNome];
                nomeChar = arquivo.ReadChars(tamanhoNome);

                string nomeLido = "";

                for (int i = 0; i < tamanhoNome; i++)
                    nomeLido += nomeChar[i];

                this.Nome = nomeLido;

                // lendo outros campos
                this.x = arquivo.ReadDouble();
                this.y = arquivo.ReadDouble();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    public void GravarRegistro(BinaryWriter arquivo)
    {
        if (arquivo != null)
        {
            char[] nomeChar = new char[tamanhoNome];
            for (int i = 0; i < tamanhoNome; i++)
                nomeChar[i] = Nome[i];
            arquivo.Write(nomeChar);

            arquivo.Write(x);
            arquivo.Write(y);
        }
    }

    public int CompareTo(Cidade outra)
    {
        return this.nome.CompareTo(outra.nome); 
    }
}
