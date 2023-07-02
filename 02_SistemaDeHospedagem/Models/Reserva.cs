using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_hospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public void CadastrarHospedes(List<Pessoa> hospedes, Reserva reserva)
        {

            if (hospedes.Count <= reserva.Suite.Capacidade)
            {
                Hospedes = hospedes;
                return;
            }

            throw new Exception("A quantidade de hospedes excedeu a capacidade da suíte. Não foi possível realizar a operação");


        }
        public void CadastrarSuite(List<Suite> disponiveis, int quarto, int diarias, List<Reserva> reservadas, Reserva reserva)
        {
            foreach (Suite disponivel in disponiveis)
            {
                if (disponivel.Quarto == quarto)
                {
                    this.Suite = disponivel;
                    this.DiasReservados = diarias;
                    reservadas.Add(reserva);
                    disponivel.Ocupado = true;
                    return;
                }
            }
            throw new Exception("Suite não encontrada");
        }

        public int ObterQuantidadeHospedes(Reserva reserva)
        {
            int numeroHospedes = reserva.Hospedes.Count;
            return numeroHospedes;
        }
        public static decimal CalcularValorDiaria(List<Reserva> reservadas, int quarto)
        {
            decimal total = 0.0M;
            decimal diarias = 0.0M;
            decimal valorDiarias = 0.0M;
            List<Reserva> auxiliar = new List<Reserva>();
            foreach (Reserva reservada in reservadas)
            {
                if (reservada.Suite.Quarto == quarto)
                {
                    diarias = (decimal)reservada.DiasReservados;
                    valorDiarias = reservada.Suite.ValorDiaria;
                    reservada.Suite.Ocupado = false;
                    auxiliar.Add(reservada);
                    if (diarias >= 10)
                    {
                        total = diarias * valorDiarias * 0.90M;
                    }
                    else
                    {
                        total = diarias * valorDiarias;
                    }
                }
                else
                {
                    Console.WriteLine("Suite não encontrada");
                }
            }
            if (total != 0.0M)
            {
                foreach (Reserva item in auxiliar)
                {
                    reservadas.Remove(item);
                }
            }
            return total;
        }
    }
}