using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class DeleteFromCartSteps : FeatureHelper
{
    [Given(@"an existing user has logged in")]
    public void GivenAnExistingUserHasLoggedIn()
    {
        var user = new UserModelBuilder()
            .SetLogin("charles")
            .SetPassword("charles")
            .Build();
        _indexPage = _homePage.LogIn(user.Login, user.Password);
    }

    [Given(@"user added ""(.*)"" to cart")]
    public void GivenUserAddedToCart(string itemName)
    {
        _itemPage = _indexPage.ViewItem(itemName);
        _itemPage.AddToCart(itemName);
    }

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