namespace Pedidos.Entities
{
    class ItensDoPedido
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Produto Produto { get; set; }

        public ItensDoPedido(int quantity, double price,Produto produto)
        {
            Quantity = quantity;
            Price = price;
            Produto = produto;
        }

        public double SubTotal()
        {
            return Quantity*Price;
        }

        public override string ToString()
        {
            return "Nome Do Produto: "+Produto.Name +" Valor Unitario: "+Produto.Price+" SubTotal : "+SubTotal();
        }

    }
}
