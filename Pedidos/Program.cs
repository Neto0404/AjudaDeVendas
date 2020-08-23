using System;
using Pedidos.Entities;
using Pedidos.Entities.Enums;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Pedidos.Entities.Execiptions;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ajuda de Controle BY: Claudinier Neto";
            Console.ForegroundColor = ConsoleColor.Green;


            string path = @"C:\HelpOfControl\Pedidos.txt";
            string path2 = @"C:\HelpOfControl\Clientes.txt";

            Directory.CreateDirectory(@"C:\HelpOfControl");
            





            try { 
               string History = File.ReadAllText(path);

                Console.WriteLine(History);

            Console.WriteLine();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: "+e.Message);
                Console.WriteLine("Não foi encontrado Histórico!");
                Console.WriteLine("Sistema Iniciado!");
                Run.RunGo();
            }
            Console.WriteLine("Precione enter tecla para iniciar o sitema!");
            
            Run.RunGo();

        }
    }
}
