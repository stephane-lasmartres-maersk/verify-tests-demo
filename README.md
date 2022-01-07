# Snapshot Tests Using C# package Verify

We used to write assertions like the following example to verify complex objects, asserting each property of the object. The problem is that adding a new property cannot be captured and, in addition, we have to update our tests.

```csharp
using Xunit;

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
}
```

Snapshot tests allow us to simplify assertion of complex objects. It generates json file capturing the differences caused by changes in code.

```csharp
using Newtonsoft.Json;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class TestsUsingVerify
{
    VerifySettings _settings = new VerifySettings();

    public TestsUsingVerify()
    {
        //_settings.DisableDiff();    // disable using a diff tool. we will use git as diff tool

        _settings.ModifySerialization(settings => 
        {
            settings.AddExtraSettings(_ =>
            {
                _.DefaultValueHandling = DefaultValueHandling.Include;
                _.NullValueHandling = NullValueHandling.Ignore;
            });
            settings.DontScrubNumericIds();
            settings.DontScrubDateTimes();
            settings.DontScrubGuids();
        });

        VerifierSettings.UseStrictJson();

        // by default any difference will make the verification failing.
        // want to capture the difference using source control?
        // call AutoVerify(). Any verification failure will not throw an exception.
        // Instead test will pass and we will see difference in source control
        _settings.AutoVerify(); 
    }

    [Fact]
    public async Task VerifyFirstOneAsync()
    {
        var first = Movies.Get().First();

        await Verifier.Verify(first, _settings);
    }
}

```

The package `Verify` will generate two files: `*.received.json` and `*.verified.json`. Any differences between those files will be capture by the diff tool of our choice since the file `*.verified.json` should be commited while the file `*.received.json` has to be ignored by source control.

With the settings used in the example, any difference will be written to the file `*.verified.json`. It makes easy to catch if the observable behavior changed for a wrong reason. 

## Example

Let us add a new property to our model `Movie`.

```csharp
class Movie
{
    // existing properties here
    public string Test { get; set; }
}
```

Let us update our movies in `Movies`.
```csharp
class Movies
{
    public static List<Movie> Get() =>
        new List<Movie>
        {
            new Movie
            {
                // existing properties here
                Test = "test"
            }
        };
}
```

Let us run the tests and check what happened to the file `*.verified.json`. We can see it was updated. It now contains the new property.

![file verified](https://github.com/stephane-lasmartres-maersk/verify-tests-demo/blob/main/doc/file%20verified.jpg?raw=true)
