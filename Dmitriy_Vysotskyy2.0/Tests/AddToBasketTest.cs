using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class AddToBasketTest 
{
    private IWebDriver _driver = new ChromeDriver();
    // private IWebDriver _driver = new EdgeDriver();

    private HomePage _homePage;
    private IndexPage _indexPage;
    
    [SetUp]
    public void Setup()
    {
        _homePage = new HomePage(_driver);
        _homePage.Navigate();
        var user = new TestUserModel();
        _indexPage = _homePage.LogIn(user.Login, user.Password);
    }
    
    [Test]
    public void AddItemToBasket_ValidProcess_ShouldBeAddedSuccessfully()
    {
        // var itemName = "Iphone 6 32gb";
        // var itemPage = _indexPage.ViewItem(itemName);
        //
        // itemPage.AddToCart(itemName);
        // var alertText = itemPage.GetAlert();
        // Assert.AreEqual("Product added.", alertText);
    }
    
    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}