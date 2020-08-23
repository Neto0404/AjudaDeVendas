using Pedidos.Entities.Execiptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Entities
{
    class Cliente
    {
        public string Name { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public Cliente()
        {

        }

        public Cliente(string name, string endereco, string cPF)
        {
            try
            {
                Name = name;
                Endereco = endereco;
                CPF = cPF;
                
            }
            catch (InvalidException e)
            {
                Console.WriteLine("error: "+e.Message);
                Console.WriteLine("Sistem Reiniciado automaticamente!");
                Run.RunGo();
                
            }
        }

        public override string ToString()
        {
            return Name+" CPF: "+CPF;
        }
    }
}
