using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class CreateValidUserTest
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
    public void CreateUser_ValidPasswdAndLogin_ShouldCreateSuccessfully()
    {
        // var user = new TestUserModel();
        // user.MixUserData();
        // string alertText = _homePage.SignUp(user.Login, user.Password);
        // Assert.AreEqual("Sign up successful.", alertText);
    }

    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}