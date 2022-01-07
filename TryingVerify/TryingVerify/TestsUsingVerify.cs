using Newtonsoft.Json;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace TryingVerify
{
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

        [Fact]
        public async Task VerifyAllAsync()
        {
            var all = Movies.Get();

            await Verifier.Verify(all, _settings);
        }
    }
}
