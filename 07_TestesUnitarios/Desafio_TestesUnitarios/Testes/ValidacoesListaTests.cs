using DesafioTestesUnitarios.Services;
using System.Collections.Generic;

namespace Testes
{
    public class ValidacoesListaTests
    {
        private ValidacoesLista _val;

        public ValidacoesListaTests(ValidacoesLista val)
        {
            _val = val;
        }

        [Fact]
        public void DeveRemoverNumerosNegativosDeUmaLista()
        {
            var lista = new List<int> { 1, 2, 3, 4, 20, -20, -14, 90, -23, 8, 50, -1 };
            
            var listaSemNegativos = _val.RemoverNumerosNegativos(lista);
            
            var resultadoEsperado = new List<int> { 1, 2, 3, 4, 20, 90, 8, 50 };

            Assert.Equal(resultadoEsperado, listaSemNegativos);
          
        }
        [Fact]
        public void DeveConterNumero20NaLista()
        {
            var lista = new List<int> { 1, 2, 3, 4, 20, -20, -14, 90, -23, 8, 50, -1 };
            var numero = 20;
            var resultado = _val.ListaContemDeterminadoNumero(lista, numero);

            Assert.True(resultado);
        }

        [Fact]
        public void NaoDeveConterONumero15NaLista()
        {
            var lista = new List<int> { 1, 2, 3, 4, 20, -20, -14, 90, -23, 8, 50, -1 };

            var numero = 15;

            var resultado = _val.ListaContemDeterminadoNumero(lista, numero);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveMultiplicarOsElementosDaListaPor2()
        {
            var lista = new List<int> { 2, 4, 5, 6 };

            var multiplicador = 2;

            var resultado = _val.MultiplicarNumerosLista(lista, multiplicador);

            var listaMultiplicadaPor2 = new List<int> { 4, 8, 10, 12 };

            Assert.Equal(listaMultiplicadaPor2, resultado);

            
        }

        [Fact]
        public void DeveRetornar5ComoMenorNumero()
        {
            var lista = new List<int> { 5, 20, 90, 8, 50 };

            var menor = 5;

            var resultado = _val.RetornarMenorNumeroLista(lista);

            Assert.Equal(menor, resultado);
        }

        [Fact]
        public void DeveRetornar50ComoMaiorNumero()
        {
            var lista = new List<int> { 5, 20, 9, 8, 50 };

            var maior = 50;

            var resultado = _val.RetornarMaiorNumeroDaLista(lista);

            Assert.Equal(maior, resultado);
        }


    }
}