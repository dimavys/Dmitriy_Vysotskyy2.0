using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public abstract class BasePage
{
    protected IWebDriver _driver;
    
    protected WebDriverWait _wait;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        PageFactory.InitElements(driver, this);
    }
}