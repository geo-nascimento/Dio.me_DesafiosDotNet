using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstraindoCelular.Enums;
using System.Text;

namespace AbstraindoCelular
{
    public abstract class Smartphone
    {
        public SistemaOperacional SistemaOperacional { get; protected set; }
        public int Numero { get; set; }
        public string Modelo { get; protected set; }
        public string IMEI { get; protected set; }
        public int Memoria { get; protected set; }
        public List<Aplicativo> Aplicativos { get; protected set; } = new List<Aplicativo>();

        public Smartphone() { }
        public Smartphone(int numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }
        public void Ligar()
        {
            Console.Write("Digite o número: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Ligando para " + numero);
        }

        public void ReceberLigacao()
        {

        }
        public void ListarAplicativos()
        {
            if (Aplicativos.Count > 0)
            {
                int contador = 1;
                int memoriaConsumida = 0;
                foreach (Aplicativo aplicativo in Aplicativos)
                {
                    Console.WriteLine($"{contador}. {aplicativo.Nome}");
                    memoriaConsumida += aplicativo.Tamanho;
                    contador++;
                }
                Console.WriteLine();
                Console.WriteLine($"Memória consumida: {memoriaConsumida} | Memória disponivel: {Memoria}");
            }
            else
            {
                Console.WriteLine("Não há aplicativos instalados");
            }
        }
        public string InformacoesSistema()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Número: " + Numero);
            sb.AppendLine("Modelo: " + Modelo);
            sb.AppendLine("IMEI: " + IMEI);
            sb.AppendLine("Memória interna: " + Memoria + "GB");

            return sb.ToString();
        }
        public abstract void InstalarAplicativo(Aplicativo app);
        public abstract void DesinstalarAplicativo(string nome);

    }
}