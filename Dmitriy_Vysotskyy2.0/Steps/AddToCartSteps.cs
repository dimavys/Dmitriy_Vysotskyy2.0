using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class AddToCartSteps
{
    private string _alertText;
    private readonly ScenarioContext _scenarioContext;
    
    public AddToCartSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"the user has opened the item ""(.*)""")]
    public void GivenTheUserHasOpenedTheItem(string itemName)
    {
        _scenarioContext.ItemPage = _scenarioContext.IndexPage.ViewItem(itemName);
    }
    
    [When(@"the user has clicks Add to cart ""(.*)"" button")]
    public void WhenTheUserHasClicksAddToCartButton(string itemName)
    {
        _scenarioContext.ItemPage.AddToCart(itemName);
        _alertText = _scenarioContext.ItemPage.GetAlert();
    }
    
    [Then(@"the user gets ""(.*)"" alert")]
    public void ThenTheUserGetsAlert(string expectedAlert)
    {
        _alertText.Should().Be(expectedAlert);
    }
}