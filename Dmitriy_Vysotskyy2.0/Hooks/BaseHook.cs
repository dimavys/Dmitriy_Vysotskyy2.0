using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class BaseHook : FeatureHelper
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        var driver = DriverWrapper.GetInstance();
        _homePage = new HomePage(driver);
        _homePage.Navigate();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        DriverWrapper.GetInstance().Quit();
    }
}