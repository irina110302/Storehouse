namespace WebApp.Models.Entities
{
    public class Storehouse
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public Storehouse()
        {

        }

        public Storehouse(int id)
        {
            Id = id;
        }
    }
}
