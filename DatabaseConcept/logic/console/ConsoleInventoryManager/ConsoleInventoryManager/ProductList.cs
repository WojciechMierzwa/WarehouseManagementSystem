using System;

namespace ConsoleInventoryManager
{
    public class ProductList
    {
        public int Id { get; set; }                // Automatically incrementing ID
        public int ProductId { get; set; }         // ID of the product
        public int OrderId { get; set; }           // ID of the associated order
        public int Quantity { get; set; }          // Quantity of the product
        public decimal UnitPrice { get; set; }     // Price per unit of the product
        public decimal TotalPrice { get; set; }    // Total price for the quantity of products

        public ProductList(int id, int productId, int orderId, int quantity, decimal unitPrice, decimal totalPrice)
        {
            Id = id;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Product ID: {ProductId}, Order ID: {OrderId}, Quantity: {Quantity}, Unit Price: {UnitPrice:C}, Total Price: {TotalPrice:C}";
        }
    }
}
