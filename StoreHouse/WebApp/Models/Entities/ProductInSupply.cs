namespace WebApp.Models.Entities
{
    public class ProductInSupply
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public string SKU { get; set; } = string.Empty;

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public ProductInSupply(int id)
        {
            Id = id;
        }

        public ProductInSupply(int id, int supplyId)
            : this(id)
        {
            SupplyId = supplyId;
        }

        public ProductInSupply(int supplyId, int amount, decimal price, string sku, int id)
            : this(id, supplyId)
        {
            SKU = sku;
            Amount = amount;
            Price = price;
        }
    }
}
