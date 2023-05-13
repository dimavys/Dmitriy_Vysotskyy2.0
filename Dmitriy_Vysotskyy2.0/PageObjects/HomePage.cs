using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy2._0.PageObjects;

public class HomePage
{
    private IWebDriver _driver;

    private string _urlLink = "https://www.demoblaze.com";
    
    private WebDriverWait _wait;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        PageFactory.InitElements(driver, this);
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
    
    [FindsBy(How = How.XPath, Using = "//button[contains(text()='Log In')]")] //??
    [CacheLookup]
    private IWebElement _btnLogIn;
    
    [FindsBy(How = How.XPath, Using = "//button[contains(text()='Sign Up')]")] //??
    [CacheLookup]
    private IWebElement _btnSignUp;
    
    public void Navigate()
    {
        _driver.Navigate().GoToUrl(_urlLink);
        _driver.Manage().Window.Maximize();
    }
    
    public void SignUp(string username, string password)
    {
        _wait.Until(ExpectedConditions.ElementExists(By.Name("Sign Up"))); //DRY is out of party
        _btnOpenSignUp.Click();
        _wait.Until(ExpectedConditions.ElementExists(By.Name("Username"))); //DRY is out of party
        _txtUsernameSignUp.SendKeys(username);
        _txtPasswordSignUp.SendKeys(password);
        _btnSignUp.Click();
    }
    
    public void LogIn(string username, string password)
    {
        _wait.Until(ExpectedConditions.ElementExists(By.Name("Log In"))); //DRY is out of party
        _btnOpenLogIn.Click();
        _wait.Until(ExpectedConditions.ElementExists(By.Name("Username"))); //DRY is out of party
        _txtUsernameLogIn.SendKeys(username);
        _txtPasswordLogIn.SendKeys(password);
        _btnLogIn.Click();
    }

}