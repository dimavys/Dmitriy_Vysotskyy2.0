using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public sealed class BaseHook : FeatureHelper
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        _driver = new ChromeDriver();
        // _driver = new EdgeDriver();
        
        _homePage = new HomePage(_driver);
        _homePage.Navigate();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit();
    }
}