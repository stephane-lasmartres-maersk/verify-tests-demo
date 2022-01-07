namespace TryingVerify
{
    internal class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public List<string> Starring { get; set; }
    }
}
