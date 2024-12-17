using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Models
{
    public class Cart
    {
        public Customer Customer { get; private set; }
        public Invoice Invoice { get; private set; }
        public List<ProductList> Products { get; private set; }

    
        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new List<ProductList>();
        }

        
        public Cart(Invoice invoice)
        {
            Invoice = invoice;
            Products = new List<ProductList>();
        }

        public void AddProduct(int productId, int quantity = 1)
        {
            if (Invoice == null)
            {
                throw new InvalidOperationException("Cannot add products without an associated Invoice.");
            }

            var newProduct = new ProductList
            {
                Id = Products.Count + 1, 
                ProductId = productId,
                InvoiceId = Invoice.Id,
                Quantity = quantity
            };

            Products.Add(newProduct);
        }

        public List<ProductList> GetProducts()
        {
            return Products;
        }
    }
}
