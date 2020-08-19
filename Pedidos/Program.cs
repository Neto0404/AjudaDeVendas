using System;
using Pedidos.Entities;
using Pedidos.Entities.Enums;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "Ajuda de Controle BY: Claudinier Neto";
            Console.ForegroundColor = ConsoleColor.Green;


            void Run()
            {
                string path = @"C:\temp\Pedidos.txt";

                Console.WriteLine("Entre Com os Dados Do Cliente: ");
                Console.Write("Nome Do CLiente: ");
                string NomeC = Console.ReadLine();
                Console.Write("Endereço Do CLiente: ");
                string EnderecoC = Console.ReadLine();

                Console.Write("CPF ou CNPJ Do CLiente: ");
                string CPFC = Console.ReadLine();


                Cliente cliente = new Cliente(NomeC, EnderecoC, CPFC);

                Pedido pedido = new Pedido();
                pedido.Cliente = cliente;

                Console.Write("Quantos Itens Foram vendidos nesse Pedido? ");
                int VP = int.Parse(Console.ReadLine());
                for (int i = 0; i < VP; i++)
                {
                    Console.WriteLine($"Entre Com os Dados Do Produto #{i + 1} :");
                    Console.Write("Nome Do Produto: ");
                    string nomeP = Console.ReadLine();
                    Console.Write("Preço Do Produto: ");
                    double PrecoP = double.Parse(Console.ReadLine());
                    Console.Write("Quantidade Vendida: ");
                    int QV = int.Parse(Console.ReadLine());
                    Produto produto = new Produto(nomeP, PrecoP);
                    ItensDoPedido item = new ItensDoPedido(QV, PrecoP, produto);
                    pedido.Adicionar(item);

                    

                }
                

                pedido.HoradoPedido = DateTime.Now;
                Console.WriteLine("Dados do Pedido: ");
                Console.WriteLine(pedido.ToString());
                try
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(pedido.ToString());
                        Console.WriteLine();
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(e.Message);
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line == "Valor Total: ")
                        {
                            Console.WriteLine(line);
                        }
                    }
                }

                Console.WriteLine("Precione espaço tecla para Reiniciar o sitema!");
                Console.ReadKey();
                Run();

            }

            Console.WriteLine("Precione Qualquer tecla para iniciar o sitema!");
            Console.ReadKey();
            Run();

        }
    }
}
