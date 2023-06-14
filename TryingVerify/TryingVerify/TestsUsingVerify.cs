using Argon;

namespace TryingVerify;

[UsesVerify]
public class TestsUsingVerify
{
    VerifySettings _settings = new VerifySettings();

    public TestsUsingVerify()
    {
        //_settings.DisableDiff();    // disable using a diff tool. we will use git as diff tool
        //_settings.ModifySerialization(settings => 
        //{
        //    settings.AddExtraSettings(_ =>
        //    {
        //        _.DefaultValueHandling = DefaultValueHandling.Include;
        //        _.NullValueHandling = NullValueHandling.Ignore;
        //    });
        //    //settings.DontScrubNumericIds();
        //    //settings.DontScrubDateTimes();
        //    //settings.DontScrubGuids();
        //});
        // need to understand how it behaves when AutoVerify is on
        //_settings.AutoVerify(); 

        _settings.AddExtraSettings(_ =>
        {
            _.DefaultValueHandling = DefaultValueHandling.Include;
            _.NullValueHandling = NullValueHandling.Ignore;
        });
        _settings.DontScrubDateTimes();
        _settings.DontScrubGuids();

        VerifierSettings.UseStrictJson();
    }

    [Fact]
    public async Task VerifyAllAsync()
    {
        var all = Movies.Get();

        await Verifier.Verify(all, _settings);
    }
}
