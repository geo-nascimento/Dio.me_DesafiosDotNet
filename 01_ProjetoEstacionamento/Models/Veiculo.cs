using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEstacionamento.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Permanencia { get; set; }

        public Veiculo(string placa, string modelo, int hora)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Permanencia = hora;
        }
    }

}