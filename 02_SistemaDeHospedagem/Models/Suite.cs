using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_hospedagem.Models
{
    public class Suite
    {
        public int Quarto { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public bool Ocupado { get; set; }

        public Suite(int quarto, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Quarto = quarto;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            Ocupado = false;
        }
    }
}