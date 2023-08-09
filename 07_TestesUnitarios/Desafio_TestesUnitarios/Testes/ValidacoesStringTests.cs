using DesafioTestesUnitarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    public class ValidacoesStringTests
    {
        private ValicacoesString _val;

        public ValidacoesStringTests(ValicacoesString val) 
        { 
            _val = val;
        }

        [Fact]
        public void DeveRetornar6QuantidadeCaracteresDaPalavraGeorge()
        {
            var resultadoEsperado = 6;

            var buscar = "George";

            var resultado = _val.RetornarQuantidadeCaracteres(buscar);


            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveConterAPalavraMiseravelNoTexto()
        {
            var texto = "Kakaroto, seu verme miserável";

            var buscar = "miserável";

            var resultado = _val.ContemCaractere(texto, buscar);

            Assert.True(resultado);
        }

        [Fact]
        public void NaoDeveConterAPalavraBonitoNoTexto()
        {
            var texto = "Eu sou feio";

            var buscar = "Bonito";

            var resultado = _val.ContemCaractere(texto, buscar);

            Assert.False(resultado);
        }

        [Fact]
        public void TextoDeveTerminarComAPalavraProcurado()
        {
            var texto = "Criminoso mais procurado";

            var buscar = "procurado";

            var resultado = _val.TextoTerminaCom(texto, buscar);

            Assert.True(resultado);
        }

    }
}
