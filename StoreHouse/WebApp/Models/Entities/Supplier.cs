namespace WebApp.Models.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Supplier(int id)
        {
            Id = id;
        }

        public Supplier(int id, string name, string address, string phone, string email) 
            : this(id)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}
