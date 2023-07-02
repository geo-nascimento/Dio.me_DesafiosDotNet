using AbstraindoCelular;
using AbstraindoCelular.View;




int opcao = MenuCompra();
Smartphone sp = null;
do
{
    sp = CriarSmartphone(opcao);
} while (sp == null);


MenuSmartphone(sp);


int MenuCompra()
{
    Console.Write("1. Iphone\n2. Android\nQual aparelho deseja comprar: ");
    int opcao = int.Parse(Console.ReadLine());
    Console.Clear();
    return opcao;
}

Smartphone CriarSmartphone(int opcao)
{
    Smartphone sp = null;
    switch (opcao)
    {
        case 1:
            (int numero, string modelo, string imei, int memoria) dadosIphone = ColetarDadosNovoSmartphone();
            sp = new Iphone(dadosIphone.numero, dadosIphone.modelo, dadosIphone.imei, dadosIphone.memoria);
            break;
        case 2:
            (int numero, string modelo, string imei, int memoria) dadosAndroid = ColetarDadosNovoSmartphone();
            sp = new Android(dadosAndroid.numero, dadosAndroid.modelo, dadosAndroid.imei, dadosAndroid.memoria);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    return sp;
}

(int, string, string, int) ColetarDadosNovoSmartphone()
{
    int numero = 0;
    string modelo = "";
    string imei = "";
    int memoria = 0;
    try
    {

        Console.Write("Número do telefone: ");
        numero = int.Parse(Console.ReadLine());
        Console.Write("Qual o modelo do aparelho: ");
        modelo = Console.ReadLine();
        //Número aleatório
        var randonInt = new Random();
        imei = randonInt.Next(1, 9999).ToString();
        Console.Write("Escolha a capacidade de armazenamento (64GB/128GB/256GB): ");
        memoria = int.Parse(Console.ReadLine());
        Console.Clear();
    }
    catch (FormatException e)
    {
        Console.WriteLine("Erro na entrada de dados: " + e.Message);
    }

    return (numero, modelo, imei, memoria);
}

void MenuSmartphone(Smartphone sp)
{
    Console.WriteLine($"Bem-vindo ao seu smartphone {sp.Modelo}");
    Console.WriteLine("_________________________________________");
    Console.WriteLine();
    Console.WriteLine(sp.InformacoesSistema());
    Console.WriteLine();
    sp.ListarAplicativos();

    Console.Write("1. Instalar um aplicativo\n2. Desinstalar um aplicativo\n Escolha a operação: ");
    int opcao = int.Parse(Console.ReadLine());
    Aplicativo app;
    switch (opcao)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Instalando um app");
            (string nome, int tamanho) dadosApp = DadosCriarApp();
            app = new Aplicativo(dadosApp.nome, dadosApp.tamanho);
            sp.InstalarAplicativo(app);
            Console.Clear();
            MenuSmartphone(sp);
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Desisntalar um app");
            Console.Write("Nome do aplicativo: ");
            string nome = Console.ReadLine();
            sp.DesinstalarAplicativo(nome);
            Console.Clear();
            MenuSmartphone(sp);
            break;
        default:
            Console.WriteLine("Opção inválida");
            MenuSmartphone(sp);
            break;
    }
}

(string, int) DadosCriarApp()
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Tamanho: ");
    int tamanho = int.Parse(Console.ReadLine());

    return (nome, tamanho);

}



