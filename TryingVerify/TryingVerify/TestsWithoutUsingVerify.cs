using Xunit;

namespace TryingVerify
{
    public class TestsWithoutUsingVerify
    {
        [Fact]
        public void VerifyFirstOne()
        {
            var first = Movies.Get().First();

            Assert.Equal("a5eaae6f-e0bc-4fd4-b120-8dedf32adeb5", first.Id.ToString());
            Assert.Equal(90_000_000, first.Budget);
            Assert.Equal(new DateTime(2013, 10, 5), first.ReleaseDate);
            Assert.Equal("The Secret Life of Walter Mitty", first.Title);

            Assert.Collection(first.Starring,
                item => Assert.Equal("Ben Stiller", item),
                item => Assert.Equal("Kristen Wiig", item),
                item => Assert.Equal("Shirley MacLaine", item),
                item => Assert.Equal("Adam Scott", item),
                item => Assert.Equal("Kathryn Hahn", item),
                item => Assert.Equal("Sean Penn", item)
            );
        }

        [Fact]
        public void VerifyAll()
        {
            var all = Movies.Get();

            var first = all[0];
            Assert.Equal("a5eaae6f-e0bc-4fd4-b120-8dedf32adeb5", first.Id.ToString());
            Assert.Equal(90_000_000, first.Budget);
            Assert.Equal(new DateTime(2013, 10, 5), first.ReleaseDate);
            Assert.Equal("The Secret Life of Walter Mitty", first.Title);

            Assert.Collection(first.Starring,
                item => Assert.Equal("Ben Stiller", item),
                item => Assert.Equal("Kristen Wiig", item),
                item => Assert.Equal("Shirley MacLaine", item),
                item => Assert.Equal("Adam Scott", item),
                item => Assert.Equal("Kathryn Hahn", item),
                item => Assert.Equal("Sean Penn", item)
            );

            var last = all[1];
            Assert.Equal("91287e2d-ca7c-48c5-95d0-43ebcd77a817", last.Id.ToString());
            Assert.Equal(275_000_000, last.Budget);
            Assert.Equal(new DateTime(2019, 12, 16), last.ReleaseDate);
            Assert.Equal("Star Wars: The Rise of Skywalker", last.Title);

            Assert.Collection(last.Starring,
                item => Assert.Equal("Carrie Fisher", item),
                item => Assert.Equal("Mark Hamill", item),
                item => Assert.Equal("Adam Driver", item),
                item => Assert.Equal("Daisy Ridley", item),
                item => Assert.Equal("John Boyega", item)
            );
        }
    }
}
