public class RecordCheckout
{
    public string productName { get; set; }
    public decimal nettoPrice { get; set; }
    public decimal vatPercentage { get; set; }
    public int quantity { get; set; }
    public decimal totalPrice => nettoPrice * quantity * (1 + vatPercentage / 100);

    public RecordCheckout(string productName, decimal nettoPrice, decimal vatPercentage, int quantity)
    {
        this.productName = productName;
        this.nettoPrice = nettoPrice;
        this.vatPercentage = vatPercentage;
        this.quantity = quantity;
    }
}
