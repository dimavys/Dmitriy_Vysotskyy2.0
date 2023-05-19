using Dmitriy_Vysotskyy2._0.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class CartPage : BasePage
{
    public CartPage(IWebDriver driver) : base(driver)
    {
        
    }
    
    [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn btn-success')]")]
    [CacheLookup]
    private IWebElement _btnPlaceOrder;
    
    [FindsBy(How = How.Id, Using = "name")]
    [CacheLookup]
    private IWebElement _txtName;
    
    [FindsBy(How = How.Id, Using = "country")]
    [CacheLookup]
    private IWebElement _txtCountry;
    
    [FindsBy(How = How.Id, Using = "city")]
    [CacheLookup]
    private IWebElement _txtCity;
    
    [FindsBy(How = How.Id, Using = "card")]
    [CacheLookup]
    private IWebElement _txtCard;
    
    [FindsBy(How = How.Id, Using = "month")]
    [CacheLookup]
    private IWebElement _txtMonth;
    
    [FindsBy(How = How.Id, Using = "year")]
    [CacheLookup]
    private IWebElement _txtYear;
    
    [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn btn-primary') and text()='Purchase']")]
    [CacheLookup]
    private IWebElement _btnPurchase;
    
    public void DeleteItem(string itemName)
    {
        var lnkDeleteItem=  _wait.Until(ExpectedConditions
            .ElementExists(By.XPath($"//td[text()='{itemName}']/parent::tr//a")));
        
        lnkDeleteItem.Click();
    }

    public bool CheckDeleteStatus(string itemName)
    {
        _wait.Until(ExpectedConditions
            .InvisibilityOfElementLocated(By.XPath($"//td[text()='{itemName}']/parent::tr//a")));
        
        var item = _driver
            .FindElements(By.XPath($"//td[text()='{itemName}']"));
        if (item.Count > 0)
            return false;

        return true;
    }

    public void PlaceOrder(TestOrderModel model)
    {
        _btnPlaceOrder.Click();
        Thread.Sleep(1500);
        
        _txtName.SendKeys(model.Name);
        _txtCountry.SendKeys(model.Country);
        _txtCity.SendKeys(model.City);
        _txtCard.SendKeys(model.Card);
        _txtMonth.SendKeys(model.Month);
        _txtYear.SendKeys(model.Year);
        
        _btnPurchase.Click();
    }

    public bool CheckOrderStatus()
    {
        Thread.Sleep(1000);
        var item = _driver
            .FindElements(By.XPath($"//h2[text()='Thank you for your purchase!']"));
        if (item.Count > 0)
            return true;

        return false;
    }
}