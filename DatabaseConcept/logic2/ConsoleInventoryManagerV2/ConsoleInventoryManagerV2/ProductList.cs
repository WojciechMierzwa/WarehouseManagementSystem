namespace ConsoleInventoryManagerV2
{
    internal class ProductList
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

        public ProductList(int id, int productId, int orderId, int quantity, double unitPrice, double totalPrice)
        {
            Id = id;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }
}
