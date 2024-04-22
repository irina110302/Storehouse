namespace WebApp.Models.Entities
{
    public class ProductInSupply
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public Sku Sku { get; set; } = new Sku("");

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public ProductInSupply(int id, int supplyId)
        {
            Id = id;
            SupplyId = supplyId;
        }

        public ProductInSupply(int id, int supplyId, Sku sku, int amount, decimal price)
            : this(id, supplyId)
        {
            Sku = sku;
            Amount = amount;
            Price = price;
        }
    }
}
