namespace WebApp.Models.Entities
{
    public class Sku
    {
        public string SKU { get; set; } = string.Empty;

        public DateTime ProductionDate { get; set; } = DateTime.Now;

        public int ProductId { get; set; }

        public decimal SaleK { get; set; }

        public Sku(string SKU)
        {
            this.SKU = SKU;
        }

        public Sku(string SKU, int productId, DateTime productionDate, decimal saleK)
            : this(SKU)
        {
            ProductionDate = productionDate;
            SaleK = saleK;
            ProductId = productId;
        }
    }
}
