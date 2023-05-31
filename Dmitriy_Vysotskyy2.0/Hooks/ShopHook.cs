using Dmitriy_Vysotskyy2._0.PageObjects;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class ShopHook : BaseHook
{
    [BeforeScenario("ShopTag")]
    public static void BeforeScenario()
    {
        var driver = DriverWrapper.GetInstance();
        _homePage = new HomePage(driver);
        _homePage.Navigate();
    }
}