namespace DesafioTestesUnitarios.Services;

public class ValicacoesString
{
    public int RetornarQuantidadeCaracteres(string texto)
    {
        return texto.Length;//Retornar a quantidade de caracteres em um texto
    }

    public bool ContemCaractere(string texto, string buscar)
    {
        return texto.Contains(buscar);
    }

    public bool TextoTerminaCom(string texto, string buscar)
    {
        return texto.EndsWith(buscar);
    }
}
