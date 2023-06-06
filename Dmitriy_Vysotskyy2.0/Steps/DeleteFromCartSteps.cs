using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class DeleteFromCartSteps
{
    private readonly ScenarioContext _scenarioContext;

    public DeleteFromCartSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [When(@"user clicks delete ""(.*)"" button")]
    public void WhenUserClicksDeleteButton(string itemName)
    {
        _scenarioContext.CartPage = _scenarioContext.ItemPage.GoToCart();
        _scenarioContext.CartPage.DeleteItem(itemName);
    }

    [Then(@"""(.*)"" must be deleted")]
    public void ThenMustBeDeleted(string itemName)
    {
        _scenarioContext.CartPage.CheckDeleteStatus(itemName)
            .Should().Be(true);
    }
}