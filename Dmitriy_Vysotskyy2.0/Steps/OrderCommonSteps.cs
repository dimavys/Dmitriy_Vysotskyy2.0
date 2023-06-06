using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class OrderCommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    public OrderCommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"user has added ""(.*)"" to cart")]
    [Given(@"user added ""(.*)"" to cart")]
    public void GivenUserHasAddedToCart(string itemName)
    {
        _scenarioContext.ItemPage = _scenarioContext.IndexPage.ViewItem(itemName);
        _scenarioContext.ItemPage.AddToCart(itemName);
    }
}