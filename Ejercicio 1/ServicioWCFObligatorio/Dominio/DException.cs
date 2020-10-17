using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DException : Exception
    {
        public DException()
        {

        }
        public DException(string msg) : base(msg)
        {

        }
    }
}
