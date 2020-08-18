using System;
using System.Collections.Generic;
using System.Text;
using Pedidos.Entities.Enums;

namespace Pedidos.Entities
{
    class Pedido
    {
        public DateTime HoradoPedido { get; set; }
        public StatusPEdido Status { get; set; }

        public double TotalV { get; set; }
        public List<ItensDoPedido> Itens { get; set; } = new List<ItensDoPedido>();
        public Cliente Cliente { get; set; }

        public Pedido(DateTime horadoPedido, StatusPEdido status, Cliente cliente)
        {
            HoradoPedido = horadoPedido;
            Status = status;
            Cliente = cliente;
        }
        public Pedido()
        {

        }

        public void Adicionar(ItensDoPedido itens)
        {
            Itens.Add(itens);

        }
        public void Remover(ItensDoPedido itens)
        {
            Itens.Remove(itens);

        }
        public double Total()
        {
            double sum = 0.0;
            foreach (ItensDoPedido item in Itens)
            {

                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("Cliente : ");
            SB.Append(Cliente.Name);
            SB.Append(" " + Cliente.CPF);
            SB.Append(" " + Cliente.Endereco);
            SB.Append(" " + HoradoPedido.ToString("dd/MM/yyyy"));
            SB.AppendLine();
            foreach (ItensDoPedido itens in Itens)
            {
                SB.AppendLine(itens.ToString());
            }
            SB.Append("Valor Total: " + Total().ToString("F2"));
            return SB.ToString();
        }
    }
}
