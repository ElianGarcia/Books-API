namespace Books_API.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int YearOfPublication { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
