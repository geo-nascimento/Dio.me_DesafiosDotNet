using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_hospedagem.Models
{//Classe auxiliar
    public class Hotel
    {
        public List<Suite> SuitesDisponiveis { get; set; } //vai receber as suítes disponíveis
        public List<Reserva> SuitesReservadas { get; set; } //Vai receber as suítes ocupadas
        public void ListarSuidesDisponiveis(List<Suite> disponiveis)
        {
            Console.WriteLine("_____SUÍTES DISPONÍVEIS_____");
            foreach (Suite disponivel in disponiveis)
            {
                Console.WriteLine($"Quarto: {disponivel.Quarto}\nTipo de saíte: {disponivel.TipoSuite} | Capacidade: {disponivel.Capacidade} | Valor da diária: {disponivel.ValorDiaria}");
                Console.WriteLine(disponivel.Ocupado ? "Status: ocupada" : "Status: disponível");
                Console.WriteLine("----------------------");
            }
        }

        public void ListarSuitesReservadas(List<Reserva> reservadas)
        {
            Console.WriteLine("_____SUÍTES RESERVADAS_____");
            foreach (Reserva reservada in reservadas)
            {
                Console.WriteLine($"Número do quarto: {reservada.Suite.Quarto} | Tipo de suíte: {reservada.Suite.TipoSuite} | Valor da diária: {reservada.Suite.ValorDiaria} | Dias reservados: {reservada.DiasReservados}");
            }

        }
    }
}