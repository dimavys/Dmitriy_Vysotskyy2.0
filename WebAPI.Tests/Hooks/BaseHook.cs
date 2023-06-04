using TechTalk.SpecFlow;
using WebAPI.Infrastructure;
using WebAPI.Tests.Features;

namespace WebAPI.Tests.Hooks;

[Binding]
public class BaseHook : FeatureHelper
{
    [BeforeFeature]
    public static void BeforeFeature()
    {
        _restApiClient = new RestApiClient();
    }

    [AfterFeature]
    public static void AfterFeature()
    {
        _restApiClient.Dispose();
    }
}