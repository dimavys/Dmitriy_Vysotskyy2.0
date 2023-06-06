using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class BaseHook
{
    [AfterScenario]
    public static void AfterScenario()
    {
        DriverWrapper.GetInstance().Quit();
    }
}