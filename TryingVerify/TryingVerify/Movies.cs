namespace TryingVerify
{
    internal class Movies
    {
        public static List<Movie> Get()
            => new List<Movie>
            {
                new Movie
                {
                    Id = Guid.Parse("a5eaae6f-e0bc-4fd4-b120-8dedf32adeb5"),
                    Title = "The Secret Life of Walter Mitty",
                    ReleaseDate = new DateTime(2013, 10, 5),
                    Budget = 90_000_000,
                    Starring = new List<string>
                    {
                        "Ben Stiller",
                        "Kristen Wiig",
                        "Shirley MacLaine",
                        "Adam Scott",
                        "Kathryn Hahn",
                        "Sean Penn"
                    },
                    Directors = new List<string>
                    {
                        "Ben Stiller"
                    },
                    Status = "Pre-production"
                },
                new Movie
                {
                    Id = Guid.Parse("91287e2d-ca7c-48c5-95d0-43ebcd77a817"),
                    Title = "Star Wars: The Rise of Skywalker",
                    ReleaseDate = new DateTime(2019, 12, 16),
                    Budget = 275_000_000,
                    Starring = new List<string>
                    {
                        "Carrie Fisher",
                        "Mark Hamill",
                        "Adam Driver",
                        "Daisy Ridley",
                        "John Boyega"
                    }
                }
            };
    }
}
