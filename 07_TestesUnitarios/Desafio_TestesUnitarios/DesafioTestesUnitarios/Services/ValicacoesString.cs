using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTestesUnitarios.Services
{
    public class ValicacoesString
    {
        public int RetornarQuantidadeCaracteres(string texto)
        {
            return texto.Length;
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
}
