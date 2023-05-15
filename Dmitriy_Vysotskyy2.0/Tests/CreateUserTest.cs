using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class CreateUserTest
{
    private IWebDriver _driver = new ChromeDriver();
    
    private HomePage _homePage;
    
    [SetUp]
    public void Setup()
    {
        _homePage = new HomePage(_driver);
        _homePage.Navigate();
    }

    [Test]
    public void CreateUser_InvalidPasswdAndLogin_ShouldCreateUnSuccessfully()
    {
        var user = new TestUserModel();
        string alertText = _homePage.SignUp(user.Login,user.Password);
        
        Assert.AreEqual("This user already exist.", alertText);
    }
    
    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}