using Dmitriy_Vysotskyy2._0.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class PlaceOrderSteps
{
    private readonly ScenarioContext _scenarioContext;
    public PlaceOrderSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [When(@"user inserts correct data and clicks place order button")]
    public void WhenUserInsertsCorrectDataAndClicksPlaceOrderButton()
    {
        _scenarioContext.CartPage = _scenarioContext.ItemPage.GoToCart();

        var orderModel = new OrderModelBuilder()
            .SetName("TestName")
            .SetCountry("Ukraine")
            .SetCity("Kyiv")
            .SetCard("1111")
            .SetMonth("4")
            .SetYear("2023")
            .Build();
        
        _scenarioContext.CartPage.PlaceOrder(orderModel);
    }
    
    [Then(@"order has been created")]
    public void ThenOrderHasBeenCreated()
    {
        _scenarioContext.CartPage.CheckOrderStatus()
            .Should().Be(true);
    }
}