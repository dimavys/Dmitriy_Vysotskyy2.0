using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class IndexPage : BasePage
{
    public IndexPage(IWebDriver driver) : base(driver)
    {
        
    }

    public ItemPage ViewItem(string itemName)
    {
        _wait.Until(ExpectedConditions
            .ElementExists(By.XPath("//a[starts-with(text(),'Welcome')]")));

        var lnkItem = _driver.FindElement(By
            .XPath($"//a[contains(@class,'hrefch') and text()='{itemName}']"));
        
        lnkItem.Click();

        return new ItemPage(_driver);
    }
}