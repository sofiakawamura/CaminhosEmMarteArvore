// Ana Clara Martin da Silveira - 23122
// Sofia Tasselli Kawamura - 23157

using System;
using System.IO;

public interface IRegistro
{
    void LerRegistro(BinaryReader arquivo, long qualRegistro);

    void GravarRegistro(BinaryWriter arquivo);

    int TamanhoRegistro { get; }
}