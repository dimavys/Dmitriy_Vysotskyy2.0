using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class DragAndDropPage
{
    private IWebDriver _driver;
    
    private WebDriverWait _wait;

    private string _urlLink = "https://www.globalsqa.com/demo-site/draganddrop/";
    
    [FindsBy(How = How.XPath, Using ="//h5[contains(text(), 'High Tatras')]")]
    [CacheLookup]
    private IWebElement _fromElement1;
    
    [FindsBy(How = How.XPath, Using ="//h5[contains(text(), 'High Tatras 2')]/parent::li")]
    [CacheLookup]
    private IWebElement _fromElement2;
    
    [FindsBy(How = How.XPath, Using = "//div[contains(@class,'bui-widget-content ui-state-default ui-droppable')]")]
    [CacheLookup]
    private IWebElement _toElement;

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

    public void DragAndDrop()
    {
        Actions builder = new Actions(_driver);
        Thread.Sleep(3000);

        builder.DragAndDrop(_fromElement1, _toElement).Perform();
        builder.DragAndDrop(_fromElement2, _toElement).Perform();

    }
    
    
}