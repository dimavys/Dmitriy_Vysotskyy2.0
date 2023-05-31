using Dmitriy_Vysotskyy2._0.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class DeleteFromCartSteps : FeatureHelper
{
    [When(@"user clicks delete ""(.*)"" button")]
    public void WhenUserClicksDeleteButton(string itemName)
    {
        _cartPage = _itemPage.GoToCart();
        _cartPage.DeleteItem(itemName);
    }

    [Then(@"""(.*)"" must be deleted")]
    public void ThenMustBeDeleted(string itemName)
    {
        _cartPage.CheckDeleteStatus(itemName)
            .Should().Be(true);
    }
}