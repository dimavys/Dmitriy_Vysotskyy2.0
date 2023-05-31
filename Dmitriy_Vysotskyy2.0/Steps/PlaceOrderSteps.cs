using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class PlaceOrderSteps : FeatureHelper
{
    [When(@"user inserts correct data and clicks place order button")]
    public void WhenUserInsertsCorrectDataAndClicksPlaceOrderButton()
    {
        _cartPage = _itemPage.GoToCart();

        var orderModel = new OrderModelBuilder()
            .SetName("TestName")
            .SetCountry("Ukraine")
            .SetCity("Kyiv")
            .SetCard("1111")
            .SetMonth("4")
            .SetYear("2023")
            .Build();
        
        _cartPage.PlaceOrder(orderModel);
    }
    
    [Then(@"order has been created")]
    public void ThenOrderHasBeenCreated()
    {
        _cartPage.CheckOrderStatus()
            .Should().Be(true);
    }
}