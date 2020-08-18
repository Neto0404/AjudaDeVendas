using System;
using Pedidos.Entities;
using Pedidos.Entities.Enums;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ajuda de Controle BY: Claudinier Neto";
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Entre Com os Dados Do Cliente: ");
            Console.Write("Nome Do CLiente: ");
            string NomeC = Console.ReadLine();
            Console.Write("Endereço Do CLiente: ");
            string EnderecoC = Console.ReadLine();

            Console.Write("CPF ou CNPJ Do CLiente: ");
            string CPFC = Console.ReadLine();


            Cliente cliente = new Cliente(NomeC,EnderecoC,CPFC);
            
            Pedido pedido = new Pedido();
            pedido.Cliente = cliente;

            Console.Write("Quantos Itens Foram vendidos nesse Pedido? ");
            int VP = int.Parse(Console.ReadLine());
            for(int i =0; i < VP; i++)
            {
                Console.WriteLine($"Entre Com os Dados Do Produto #{i+1} :");
                Console.Write("Nome Do Produto: ");
                string nomeP = Console.ReadLine();
                Console.Write("Preço Do Produto: ");
                double PrecoP = double.Parse(Console.ReadLine());
                Console.Write("Quantidade Vendida: ");
                int QV = int.Parse(Console.ReadLine());
                Produto produto = new Produto(nomeP, PrecoP);
                ItensDoPedido item = new ItensDoPedido(QV,PrecoP,produto);
                pedido.Adicionar(item); 
            }
            // Console.Write("Qual o status do pedido? ");

            pedido.HoradoPedido = DateTime.Now;
            Console.WriteLine("Dados do Pedido: ");
            Console.WriteLine(pedido.ToString());
            

            Console.WriteLine("Precione Qualquer tecla para finalizar o sitema!");
            Console.ReadKey();


        }
    }
}
