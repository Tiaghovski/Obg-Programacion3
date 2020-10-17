using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {

        }
    }
}