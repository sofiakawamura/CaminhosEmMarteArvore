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
    ListaSimples<Caminho> caminhos = new ListaSimples<Caminho>();

    public string Nome
    {
        get => this.nome.Trim();
        set
        {
            this.nome = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }
    }

    public double X
    {
        get => this.x;
        set
        {
            if (value > 1 || value < 0)
                throw new Exception("Coordenada inválida!");
            this.x = value;
        }
    }

    public double Y 
    {
        get => this.y;
        set
        {
            if (value > 1 || value < 0)
                throw new Exception("Coordenada inválida!");
            this.y = value;
        }
    }

    public ListaSimples<Caminho> Caminhos => this.caminhos;

    public const int tamanhoRegistro = tamanhoNome + sizeof(double) + sizeof(double);

    public int TamanhoRegistro => tamanhoRegistro;

    public Cidade() { }

    public Cidade(string nome, double x, double y)
    {
        this.Nome = nome;
        this.x = x;
        this.y = y;
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
        return this.nome.Trim().CompareTo(outra.nome.Trim()); 
    }

    public override String ToString()
    {
        return nome.Trim();
    }
}
