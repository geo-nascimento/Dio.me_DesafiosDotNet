
List<int> lista = new List<int> { 5, 6, -10, -20, 100, -3 };

var listaResult = lista.Where(x => x > 0).ToList();

foreach (var item in listaResult)
{
    Console.WriteLine(item);
}