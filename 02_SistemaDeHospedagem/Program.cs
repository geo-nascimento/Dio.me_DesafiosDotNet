using Sistema_de_hospedagem.Models;
using System.Globalization;
//Instanciar o hotel
Hotel hotel = new Hotel();
hotel.SuitesDisponiveis = new List<Suite>();
hotel.SuitesReservadas = new List<Reserva>();

Menu();


void Programa(int opcao)
{
    switch (opcao)
    {
        case 1:/*Cadastro de suíte*/
            (int quarto, string tipoSuite, int capacidade, decimal valorDiaria) dadosSuite = ColetarDadosNovaSuite();
            Suite suite = new Suite(dadosSuite.quarto, dadosSuite.tipoSuite, dadosSuite.capacidade, dadosSuite.valorDiaria);
            hotel.SuitesDisponiveis.Add(suite);
            RetornarMenu();
            break;

        case 2:/*Listar as suítes disponíveis*/
            hotel.ListarSuidesDisponiveis(hotel.SuitesDisponiveis);
            RetornarMenu();
            break;

        case 3:/*Cadastrar hóspedes*/
            //escolher a suite e dias de reserva//
            (int NumeroQuarto, int qtdDiarias) suiteEscolhida = ColetarDadosSuiteReservada();
            Reserva reserva = new Reserva();
            reserva.CadastrarSuite(hotel.SuitesDisponiveis, suiteEscolhida.NumeroQuarto, suiteEscolhida.qtdDiarias, hotel.SuitesReservadas, reserva);

            //Captar os hóspedes//
            List<Pessoa> listaDeHospedes = new List<Pessoa>();
            listaDeHospedes = ColetarDadosHospedes();
            reserva.CadastrarHospedes(listaDeHospedes, reserva);
            RetornarMenu();
            break;

        case 4:/*Listar suítes ocupadas*/
            hotel.ListarSuitesReservadas(hotel.SuitesReservadas);
            RetornarMenu();
            break;

        case 5: /*Calcular diárias*/
            int quarto = checkOut();
            hotel.ListarSuitesReservadas(hotel.SuitesReservadas);
            decimal valorPagar = Reserva.CalcularValorDiaria(hotel.SuitesReservadas, quarto);
            Console.WriteLine("Valor a pagar: " + valorPagar.ToString("F2", CultureInfo.InvariantCulture) + " R$");
            RetornarMenu();
            break;

        case 6: /*Encerrar programa*/
            Console.WriteLine("Aperte uma tecla para sair do programa");
            Console.ReadKey();
            System.Environment.Exit(0);
            break;

        default:
            RetornarMenu();
            break;
    }
}
(int, string, int, decimal) ColetarDadosNovaSuite()
{
    Console.WriteLine("_____CADASTRO DE SUÍTE_____");
    Console.Write("Número do quarto: ");
    int quarto = int.Parse(Console.ReadLine());
    Console.Write("Tipo de suíte (convencional/premium): ");
    string tipoSuite = Console.ReadLine();
    Console.Write("Capacidade: ");
    int capacidade = int.Parse(Console.ReadLine());
    Console.Write("Valor da diária: ");
    decimal valorDiaria = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    return (quarto, tipoSuite, capacidade, valorDiaria);
}
void RetornarMenu()
{
    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    Menu();
}
(int, int) ColetarDadosSuiteReservada()
{
    Console.WriteLine("_____CADASTRAR HÓSPEDES_____");
    hotel.ListarSuidesDisponiveis(hotel.SuitesDisponiveis);
    Console.Write("Escolha uma suíte: ");
    int suite = int.Parse(Console.ReadLine());
    Console.Write("Número de diárias: ");
    int diarias = int.Parse(Console.ReadLine());

    return (suite, diarias);
}
void Menu()
{
    Console.WriteLine("_____SISTEMA DE HOSPEDAGEM_____");
    Console.WriteLine("1. Cadastrar uma suíte\n2. Listar suítes disponíveis\n3. Cadastrar hóspede\n4. Listar suítes ocupadas\n5. Saida e Cálculo de diárias\n6. Encerrar programa");
    Console.Write("Opção: ");
    int opcao = int.Parse(Console.ReadLine());
    Console.Clear();
    Programa(opcao);
}
List<Pessoa> ColetarDadosHospedes()
{
    List<Pessoa> listaDeHospedes = new List<Pessoa>();
    Console.Write("Quantidade de hóspedes: ");
    int qtdHospedes = int.Parse(Console.ReadLine());
    Console.WriteLine();
    for (int i = 0; i < qtdHospedes; i++)
    {
        Console.WriteLine($"Hospede {i + 1}");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Sobrenome: ");
        string sobrenome = Console.ReadLine();
        Pessoa hospedes = new Pessoa(nome, sobrenome);
        listaDeHospedes.Add(hospedes);
        Console.WriteLine();
    }
    return listaDeHospedes;
}
int checkOut()
{
    Console.WriteLine("_____CHECK-OUT_____");
    Console.Write("Suíte para check-out: ");
    int quarto = int.Parse(Console.ReadLine());
    return quarto;
}