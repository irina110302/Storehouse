namespace WebApp.Models.Entities
{
    public class Supply
    {
        public int Id { get; set; }

        public int StorehouseId { get; set; }

        public int SupplierId { get; set; }

        public DateTime DateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public Supply()
        {

        }

        public Supply(int id)
        {
            Id = id;
        }

        public Supply(int supplierId, int storehouseId)
        {
            StorehouseId = storehouseId;
            SupplierId = supplierId;
        }

        public Supply(int id, int supplierId, int storehouseId, DateTime dateTime, decimal totalPrice) 
            : this(id)
        {
            StorehouseId = storehouseId;
            SupplierId = supplierId;
            DateTime = dateTime;
            TotalPrice = totalPrice;
        }
    }
}
