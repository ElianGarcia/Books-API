namespace Books_API.Entities
{
    public class Dashboard
    {
        public int TotalBooks { get; set; }
        public int TotalBooksRegToday { get; set; }
        public int TotalBooksRegThisMonth { get; set; }

        public Dashboard()
        {
            TotalBooks = 0;
            TotalBooksRegToday = 0;
            TotalBooksRegThisMonth = 0;
        }
    }
}
