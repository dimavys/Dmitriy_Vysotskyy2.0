using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class PlaceOrderSteps : FeatureHelper
{
    [Given(@"user logged in")]
    public void GivenUserLoggedIn()
    {
        var user = new TestUserModel();
        _indexPage = _homePage.LogIn(user.Login, user.Password);
    }

    [Given(@"user has added ""(.*)"" to cart")]
    public void GivenUserHasAddedToCart(string itemName)
    {
        _itemPage = _indexPage.ViewItem(itemName);
        _itemPage.AddToCart(itemName);
    }

    [When(@"user inserts correct data and clicks place order button")]
    public void WhenUserInsertsCorrectDataAndClicksPlaceOrderButton()
    {
        _cartPage = _itemPage.GoToCart();
        _cartPage.PlaceOrder(new TestOrderModel());
    }
    
    [Then(@"order has been created")]
    public void ThenOrderHasBeenCreated()
    {
        _cartPage.CheckOrderStatus()
            .Should().Be(true);
    }
}