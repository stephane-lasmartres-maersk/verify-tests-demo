namespace TryingVerify
{
    internal class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public List<string> Starring { get; set; }
        public List<string> Directors { get; set; }
        public int Points { get; set; } = 10;
        public string Status { get; set; }
    }
}
