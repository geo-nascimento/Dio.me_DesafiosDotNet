namespace DesafioTestesUnitarios.Services;

public class ValidacoesLista
{
    public List<int> RemoverNumerosNegativos(List<int> numeros)
    {
        var listaSemNegativos = numeros.Where(x => x > 0).ToList();
        
        return listaSemNegativos;
        
    }

    public bool ListaContemDeterminadoNumero(List<int> numeros, int numero)
    {
        bool existe = numeros.Contains(numero);

        return existe;
    }

    public List<int> MultiplicarNumerosLista(List<int> numeros,int multiplicador)
    {
        List<int> numerosMultiplicados = numeros.Select(x => x * multiplicador).ToList();

        return numerosMultiplicados;
    }

    public int RetornarMaiorNumeroDaLista(List<int> numeros)
    {
        var resultado = numeros.Max(x => x);

        return resultado;
    }

    public int RetornarMenorNumeroLista(List<int> numeros)
    {
        var resultado = numeros.Min(x => x);

        return resultado;
    }

}
