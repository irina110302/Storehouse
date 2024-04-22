namespace WebApp.Models.Entities
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Color()
        {

        }

        public Color(int id)
        {
            Id = id;
        }

        public Color(int id, string name) : this(id)
        {
            Name = name;
        }
    }
}
