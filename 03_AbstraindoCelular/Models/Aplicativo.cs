using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstraindoCelular.Enums;

namespace AbstraindoCelular
{
    public class Aplicativo
    {
        public string Nome { get; protected set; }
        public int Tamanho { get; protected set; }

        public Aplicativo(string nome, int tamanho)
        {
            Nome = nome;
            Tamanho = tamanho;
        }
    }
}