using ProjetoEstacionamento.Models;

List<Veiculo> estacionado = new List<Veiculo>(); //posso estaciar a lista do tipo veiculo sem instanciar um objeto do tipo veiculo antes
decimal valorFixo = 0.00M;
decimal valorHora = 0.00M;

Menu();


void Menu()
{
    Console.WriteLine("O que deseja fazer? Digite uma opção");
    Console.WriteLine("1 - Cadastrar Veículo \n2 - Remover Veículo \n3 - Listar Veículos \n4 - Encerrar \n5 - Alterar valor fixo e por hora");
    Console.Write("Opção escolhida: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            CadastrarVeiculo();
            break;
        case 2:
            RemoverVeiculo();
            break;
        case 3:
            ListarVeiculos();
            break;
        case 4:
            System.Environment.Exit(0);
            break;
        case 5:
            AlterarValores();
            break;
        default:
            Menu();
            break;
    }

}

void CadastrarVeiculo()
{
    Console.Clear();
    Console.WriteLine("CADASTRO DE VEÍCULO");
    Console.WriteLine("Valor fixo: " + valorFixo + "\nValor por hora: " + valorHora);

    Console.Write("Modelo do Veículo: ");
    string modelo = Console.ReadLine();
    Console.Write("Placa do veículo: ");
    string placa = Console.ReadLine();
    Console.Write("Tempo parado: ");
    int horasParado = int.Parse(Console.ReadLine());

    Veiculo vc = new Veiculo(placa, modelo, horasParado);
    estacionado.Add(vc);
    Console.Write("Pressione uma tecla para sair");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

void RemoverVeiculo()
{
    Console.Clear();
    Console.WriteLine("REMOVER VEÍCULO");
    Console.WriteLine("Valor fixo: " + valorFixo + "\nValor por hora: " + valorHora);
    Console.WriteLine();

    //listar veículos estacionados
    int contador = 0;
    foreach (Veiculo carro in estacionado)
    {
        contador++;
        Console.WriteLine("Veículo " + contador);
        Console.WriteLine("Modelo: " + carro.Modelo);
        Console.WriteLine("Placa: " + carro.Placa);
        Console.WriteLine("Horas parado: " + carro.Permanencia);
        Console.WriteLine();

    }
    //Remover um veículo
    Console.Write("Qual veículo deseja remover? Insira a placa:");
    string placa = Console.ReadLine();
    int horas = 0;
    //lista de apoio
    List<Veiculo> itensExcluir = new List<Veiculo>();
    foreach (Veiculo carro in estacionado)
    {
        if (placa == carro.Placa)
        {
            horas = carro.Permanencia;
            itensExcluir.Add(carro);
        }
        else
        {
            Console.WriteLine("Carro não encontrado. Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
            Menu();
        }

    }
    //itera sobre a lista auxiliar e exclui da lista estacionado
    foreach (Veiculo carro in itensExcluir)
    {
        estacionado.Remove(carro);
    }

    CalcularValor(horas, valorFixo, valorHora);

    Console.Write("Pressione uma tecla para sair");
    Console.ReadKey();
    Console.Clear();
    Menu();

}

void CalcularValor(int horas, decimal valorFixo, decimal valorHora)
{
    decimal valoPagar = valorFixo + horas * valorHora;
    Console.WriteLine("Valor fixo: " + valorFixo);
    Console.WriteLine("Valor por hora: " + valorHora);
    Console.WriteLine("Valor a pagar: " + valoPagar + " R$");
}

void ListarVeiculos()
{
    Console.Clear();
    Console.WriteLine("LISTA DE VEÍCULOS");
    Console.WriteLine("Valor fixo: " + valorFixo + "\nValor por hora: " + valorHora);
    Console.WriteLine();
    int contador = 0;
    foreach (Veiculo carro in estacionado)
    {
        contador++;
        Console.WriteLine("Veículo " + contador);
        Console.WriteLine("Modelo: " + carro.Modelo);
        Console.WriteLine("Placa: " + carro.Placa);
        Console.WriteLine();

    }
    Console.Write("Pressione uma tecla para sair");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

void AlterarValores()
{
    Console.Clear();
    Console.WriteLine("ALTERAR VALORES");
    Console.WriteLine("Insira os novo valor fixo e por hora");
    Console.Write("Fixo: ");
    valorFixo = decimal.Parse(Console.ReadLine());
    Console.Write("Por hora: ");
    valorHora = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Os novos valores fixo e por hora: " + valorFixo + " R$" + " e " + valorHora + " R$, respectivamente.");

    Console.WriteLine("Pressione uma tecla para sair");
    Console.ReadKey();
    Console.Clear();
    Menu();
}