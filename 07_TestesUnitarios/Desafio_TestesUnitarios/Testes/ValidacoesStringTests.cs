using DesafioTestesUnitarios.Services;

namespace Testes;

public class ValidacoesStringTests
{
    private ValicacoesString _val;

    public ValidacoesStringTests()
    {
        _val = new ValicacoesString();
    }

    [Fact]
    public void DeveContarOsCaracteresDaPalavraGeorgeERetornar6()
    {
        var resultadoEsperado = 6;

        var buscar = "George";

        var resultado = _val.RetornarQuantidadeCaracteres(buscar);


        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveConterAPalavraMiseravelNoTextoERetornarVerdadeiro()
    {
        var texto = "Kakaroto, seu verme miseravel";

        var buscar = "miseravel";

        var resultado = _val.ContemCaractere(texto, buscar);

        Assert.True(resultado);
    }

    [Fact]
    public void DeveVerificarSeContemAPalavraBonitoERetornarFalso()
    {
        var texto = "Eu sou feio";

        var buscar = "Bonito";

        var resultado = _val.ContemCaractere(texto, buscar);

        Assert.False(resultado);
    }

    [Fact]
    public void DeveVerificarSeOTextoTerminaComAPalavraProcuradoERetornarVerdadeiro()
    {
        var texto = "Criminoso mais procurado";

        var buscar = "procurado";

        var resultado = _val.TextoTerminaCom(texto, buscar);

        Assert.True(resultado);
    }

}
