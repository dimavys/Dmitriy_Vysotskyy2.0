using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class DeleteFromBasketTest
{
    private IWebDriver _driver = new ChromeDriver();
    
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
    public void DeleteItemFromBasket_ValidProcess_ShouldBeDeletedSuccessfully()
    {
        var itemName = "Samsung galaxy s6";
        var itemPage = _indexPage.ViewItem(itemName);
        itemPage.AddToCart(itemName);
        
        var cartPage = itemPage.GoToCart();
        cartPage.DeleteItem(itemName);
        
        Assert.IsTrue(cartPage.CheckDeleteStatus(itemName));
    }
    
    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}