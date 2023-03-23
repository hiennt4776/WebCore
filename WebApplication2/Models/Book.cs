namespace WebApplication2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public double Price { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
