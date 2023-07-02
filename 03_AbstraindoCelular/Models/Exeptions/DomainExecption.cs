using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstraindoCelular.Exeptions
{
    public class DomainExecption : ApplicationException
    {
        public DomainExecption(string message) : base(message) { }
    }
}