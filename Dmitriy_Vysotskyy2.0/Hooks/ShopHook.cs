using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.PageObjects;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class ShopHook
{
    [BeforeScenario("ShopTag")]
    public static void BeforeScenario()
    {
        var driver = DriverWrapper.GetInstance();
        FeatureHelper.HomePage = new HomePage(driver);
        FeatureHelper.HomePage.Navigate();
    }
}