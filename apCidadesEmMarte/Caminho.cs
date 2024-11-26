// Ana Clara Martin da Silveira - 23122
// Sofia Tasselli Kawamura - 23157

using System;
using System.IO;
using System.Windows.Forms;

public class Caminho : IComparable<Caminho>, IRegistro
{
    public const int tamanhoNome = 15;
    string cidadeOrigem, cidadeDestino;
    int distancia, tempo, custo;

    public string CidadeOrigem 
    { 
        get => cidadeOrigem.Trim().Trim('\0'); 
        set
        {
            cidadeOrigem = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }
    }

    public string CidadeDestino 
    { 
        get => cidadeDestino.Trim().Trim('\0'); 
        set
        {
            cidadeDestino = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }
    }

    public int Distancia 
    { 
        get => distancia;
        set
        {
            if (value < 0)
                throw new Exception("A distância não pode ser negativa!");
            distancia = value;
        }
    }

    public int Tempo 
    { 
        get => tempo;
        set
        {
            if (value < 0)
                throw new Exception("O tempo não pode ser negativo!");
            tempo = value;
        }
    }

    public int Custo 
    { 
        get => custo;
        set
        {
            if (value < 0)
                throw new Exception("O custo não pode ser negativo!");
            custo = value;
        }
    }

    public const int tamanhoRegistro = tamanhoNome + tamanhoNome + sizeof(int) + sizeof(int) + sizeof(int);

    public int TamanhoRegistro => tamanhoRegistro;

    public Caminho() { }

    public Caminho(string cidadeOrigem, string cidadeDestino, int distancia, int tempo, int custo)
    {
        this.CidadeOrigem = cidadeOrigem;
        this.CidadeDestino = cidadeDestino;
        this.Distancia = distancia;
        this.Tempo = tempo;
        this.Custo = tempo;
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
                char[] origemChar = new char[tamanhoNome];
                origemChar = arquivo.ReadChars(tamanhoNome);

                string nomeOrigem = "";

                for (int i = 0; i < tamanhoNome; i++) 
                    nomeOrigem += origemChar[i];

                this.CidadeOrigem = nomeOrigem;

                // lendo nome da cidade de destino
                char[] destinoChar = new char[tamanhoNome];
                destinoChar = arquivo.ReadChars(tamanhoNome);

                string nomeDestino = "";

                for (int i = 0; i < tamanhoNome; i++)
                    nomeDestino += destinoChar[i];

                this.CidadeDestino = nomeDestino;

                // lendo outros campos
                this.Distancia = arquivo.ReadInt32();
                this.Tempo = arquivo.ReadInt32();
                this.Custo = arquivo.ReadInt32();
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
            // escreve nome da cidade de origem
            char[] origemChar = new char[tamanhoNome];
            for (int i = 0; i < tamanhoNome; i++)
                origemChar[i] = cidadeOrigem[i];
            arquivo.Write(origemChar);

            // escreve nome da cidade de destino
            char[] destinoChar = new char[tamanhoNome];
            for (int i = 0; i < tamanhoNome; i++)
                destinoChar[i] = cidadeDestino[i];
            arquivo.Write(destinoChar);

            // escreve outros campos
            arquivo.Write(Distancia);
            arquivo.Write(Tempo);
            arquivo.Write(Custo);
        }
    }

    public int CompareTo(Caminho outro)
    {
        if (CidadeOrigem == outro.CidadeOrigem && CidadeDestino == outro.CidadeDestino)
            return 0;
        return -1;
    }
}
