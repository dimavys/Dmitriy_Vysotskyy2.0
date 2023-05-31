using Dmitriy_Vysotskyy2._0.Common;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class BaseHook : FeatureHelper
{
    [AfterScenario]
    public static void AfterScenario()
    {
        DriverWrapper.GetInstance().Quit();
        //DriverWrapper.GetInstance().Dispose();
    }
}