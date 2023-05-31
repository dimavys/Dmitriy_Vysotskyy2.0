using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class ItemPage : BasePage
{
    [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'btn btn-success btn-lg')]")]
    [CacheLookup]
    private IWebElement _lnkAddToCart;
    
    [FindsBy(How = How.Id, Using = "cartur")]
    [CacheLookup]
    private IWebElement _lnkOpenCart;
    
    public ItemPage(IWebDriver driver) : base(driver)
    {
       
    }

    public void AddToCart(string itemName)
    {
        _wait.Until(ExpectedConditions
            .ElementExists(By.XPath($"//h2[contains(text(),'{itemName}')]")));
        
        _lnkAddToCart.Click();
    }

    public string GetAlert()
    {
        _wait.Until(ExpectedConditions.AlertIsPresent());
        return _driver.SwitchTo().Alert().Text;
    }

    public CartPage GoToCart()
    {
        _lnkOpenCart.Click();
        return new CartPage(_driver);
    }
}