using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstraindoCelular;
using AbstraindoCelular.Exeptions;
using AbstraindoCelular.Enums;

namespace AbstraindoCelular.View
{
    public class Iphone : Smartphone
    {
        public Iphone(int numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
            SistemaOperacional = SistemaOperacional.IOS;
        }

        public override void InstalarAplicativo(Aplicativo app)
        {
            if (Memoria > 0 && app.Tamanho <= Memoria)
            {
                Aplicativos.Add(app);
                Memoria -= app.Tamanho;
            }
            else
            {
                throw new DomainExecption("Memória interna excedida");
            }
        }

        public override void DesinstalarAplicativo(string nome)
        {

            if (Aplicativos.Count > 0)
            {
                Aplicativo app = null;
                foreach (Aplicativo aplicativo in Aplicativos)
                {
                    if (aplicativo.Nome == nome)
                    {
                        app = aplicativo;
                    }
                }
                Aplicativos.Remove(app);
                Memoria += app.Tamanho;
            }
            else
            {
                throw new DomainExecption("Não foi encontrado aplicativo para desinstalar");
            }
        }
    }
}