using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Dmitriy_Vysotskyy2._0;

public class WebDriverFactory
{
    public static IWebDriver GetWebDriver(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Edge:
                return new EdgeDriver();
            case BrowserType.Chrome:
                return new ChromeDriver();
            default:
                throw new Exception();
        }
    }
}