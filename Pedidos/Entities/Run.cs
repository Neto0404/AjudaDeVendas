﻿using System;
using Pedidos.Entities;
using Pedidos.Entities.Enums;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Pedidos.Entities.Execiptions;

namespace Pedidos.Entities
{
    class Run
    {
        public static void RunGo()
        {
            string path = @"C:\HelpOfControl\Pedidos.txt";
            string path2 = @"C:\HelpOfControl\Clientes.txt";

            if (File.Exists(path) && File.Exists(path2))
            {

            }
            else if (!File.Exists(path) && !File.Exists(path2))
            {
                File.Create(path);
                File.Create(path2);

            }
            else if (!File.Exists(path))
            {

                File.Create(path2);
            }



            Pedido pedido = new Pedido();
            try
            {
                Console.WriteLine("Entre Com os Dados Do Cliente: ");
                Console.Write("Nome Do CLiente: ");
                string NomeC = Console.ReadLine();
                Console.Write("Endereço Do CLiente: ");
                string EnderecoC = Console.ReadLine();
                Console.Write("CPF ou CNPJ Do CLiente: ");
                string CPFC = Console.ReadLine();

                Cliente cliente = new Cliente(NomeC, EnderecoC, CPFC);


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

            }
            catch (InvalidException e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Sistema Reiniciado automaticamente!");
                Run.RunGo();
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
            try
            {
                using (StreamWriter sw = File.AppendText(path2))
                {
                    sw.WriteLine(pedido.Cliente.ToString());
                    Console.WriteLine();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


            string pathCliente = @"C:\HelpOfControl\"+pedido.Cliente.Name+".txt";
            if (File.Exists(pathCliente))
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(pathCliente))
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


            }
            else{

                using (File.Create(pathCliente));


                try
                {
                    using (StreamWriter sw = File.AppendText(pathCliente))
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


            }



            Console.WriteLine("Precione ENTER tecla para Reiniciar o sitema!");
                Console.ReadKey();
                RunGo();
        }
    }
}

