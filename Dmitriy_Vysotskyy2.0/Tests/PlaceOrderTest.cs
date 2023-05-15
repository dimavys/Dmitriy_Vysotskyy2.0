using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class PlaceOrderTest
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
    public void PlaceOrder_ValidData_ShouldBeCreatedSuccessfully()
    {
        var itemName = "Iphone 6 32gb";
        var itemPage = _indexPage.ViewItem(itemName);
        itemPage.AddToCart(itemName);
        
        var cartPage = itemPage.GoToCart();
        cartPage.PlaceOrder(new TestOrderModel());

        Assert.IsTrue(cartPage.CheckOrderStatus());
    }
    
    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}