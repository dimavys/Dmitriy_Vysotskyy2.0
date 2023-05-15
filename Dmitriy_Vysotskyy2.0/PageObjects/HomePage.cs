using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class HomePage : BasePage
{
    private string _urlLink = "https://www.demoblaze.com";

    public HomePage(IWebDriver driver) : base(driver)
    {
       
    }
    
    [FindsBy(How = How.Id, Using = "signin2")]
    [CacheLookup]
    private IWebElement _btnOpenSignUp;
    
    [FindsBy(How = How.Id, Using = "login2")]
    [CacheLookup]
    private IWebElement _btnOpenLogIn;
    
    [FindsBy(How = How.Id, Using = "sign-username")]
    [CacheLookup]
    private IWebElement _txtUsernameSignUp;

    [FindsBy(How = How.Id, Using = "sign-password")]
    [CacheLookup]
    private IWebElement _txtPasswordSignUp;
    
    [FindsBy(How = How.Id, Using = "loginusername")]
    [CacheLookup]
    private IWebElement _txtUsernameLogIn;

    [FindsBy(How = How.Id, Using = "loginpassword")]
    [CacheLookup]
    private IWebElement _txtPasswordLogIn;
    
    [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'btn btn-primary') and text()='Log in']")]
    [CacheLookup]
    private IWebElement _btnLogIn;
    
    [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'btn btn-primary') and text()='Sign up']")]
    [CacheLookup]
    private IWebElement _btnSignUp;
    
    public void Navigate()
    {
        _driver.Navigate().GoToUrl(_urlLink);
        _driver.Manage().Window.Maximize();
    }
    
    public string SignUp(string username, string password)
    {
        _wait.Until(ExpectedConditions.ElementExists(By.Id("signin2"))); //DRY is out of party
        _btnOpenSignUp.Click();
        
       // _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/div[3]/button[1]"))); //DRY is out of party
        Thread.Sleep(2000); //no idea how to solve it
        
        _txtUsernameSignUp.SendKeys(username);
        _txtPasswordSignUp.SendKeys(password);
        
        _btnSignUp.Click();
        
        _wait.Until(ExpectedConditions.AlertIsPresent());
        return _driver.SwitchTo().Alert().Text;
    }
    
    public IndexPage LogIn(string username, string password)
    {
        _wait.Until(ExpectedConditions.ElementExists(By.Id("login2"))); //DRY is out of party
        _btnOpenLogIn.Click();
        
        Thread.Sleep(2000);
        // _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[3]/div/div/div[3]/button[2]"))); //DRY is out of party
        
        _txtUsernameLogIn.SendKeys(username);
        _txtPasswordLogIn.SendKeys(password);

        _btnLogIn.Click();
        
        return new IndexPage(_driver);
    }

}