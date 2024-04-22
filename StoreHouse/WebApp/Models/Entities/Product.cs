namespace WebApp.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public Color? Color { get; set; }

        public Product(int id)
        {
            Id = id;
        }

        public Product(int id, string name, string manufacturer, Color color) 
            : this(id)
        {
            Name = name;
            Manufacturer = manufacturer;
            Color = color;
        }

        public Product(int id, string name, string manufacturer)
            : this(id)
        {
            Name = name;
            Manufacturer = manufacturer;
        }
    }
}
