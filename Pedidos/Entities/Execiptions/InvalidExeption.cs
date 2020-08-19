using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Entities.Execiptions
{
    class InvalidException : ApplicationException
    {


        public InvalidException(string message) : base(message)
        {
            Console.WriteLine("Sistema Reiniciado automaticamente!");
            Run.RunGo();
        }

    }
}
