using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class DragAndDropPage
{
    private IWebDriver _driver;
    
    private WebDriverWait _wait;

    private string _urlLink = "https://www.globalsqa.com/demo-site/draganddrop/";
    
    public DragAndDropPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        PageFactory.InitElements(driver, this);
    }

    public void Navigate()
    {
        _driver.Navigate().GoToUrl(_urlLink);
        _driver.Manage().Window.Maximize();
    }

    public void DragAndDrop(string imgName1, string imgName2)
    {
        IWebElement fraElement = _driver.FindElement(By.CssSelector("iframe.demo-frame"));
        _driver.SwitchTo().Frame(fraElement);

        Actions builder = new Actions(_driver);
        
        var _fromElement1 = _wait.Until(ExpectedConditions.ElementIsVisible(
            By.XPath($"//h5[contains(text(),'{imgName1}')]/parent::li")));
        
        var _fromElement2 = _wait.Until(ExpectedConditions.ElementIsVisible(
            By.XPath($"//h5[contains(text(),'{imgName2}')]/parent::li")));
        
        var _toElement = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("trash")));

        builder.DragAndDrop(_fromElement1, _toElement).Perform();
        builder.DragAndDrop(_fromElement2, _toElement).Perform();

        _driver.SwitchTo().DefaultContent();
    }

    public bool CheckImageStatus(string imgName1, string imgName2)
    {
        IWebElement fraElement = _driver.FindElement(By.CssSelector("iframe.demo-frame"));
        _driver.SwitchTo().Frame(fraElement);
        
        var trashElement = _driver.FindElement(By.Id("trash"));
        
        var elements = trashElement
            .FindElements(By.XPath($"//h5[contains(text(),'{imgName1}')] | //h5[contains(text(),'{imgName2}')]"));

        if (elements.Count == 2)
            return true;
        
        _driver.SwitchTo().DefaultContent();
        return false;

    }
    
}