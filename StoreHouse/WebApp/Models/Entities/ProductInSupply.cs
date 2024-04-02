namespace WebApp.Models.Entities
{
    public class ProductInSupply : Product
    {
        public int SupplyId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public ProductInSupply(string sku) : base(sku)
        {

        }

        public ProductInSupply(
            int supplyId,
            string name, 
            string manufacturer, 
            string color, 
            DateTime productionDate, 
            int amount, 
            decimal price
            ) : base(name, manufacturer, color, productionDate)
        {
            SupplyId = supplyId;
            Price = price;
            Amount = amount;
        }
    }
}
