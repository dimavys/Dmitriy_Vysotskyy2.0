using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class AddToCartSteps : FeatureHelper
{
    private string _alertText;
    
    [Given(@"a user has logged in")]
    public void GivenAUserHasLoggedIn()
    {
        var user = new UserModelBuilder()
            .SetLogin("charles")
            .SetPassword("charles")
            .Build();
        
        _indexPage = _homePage.LogIn(user.Login, user.Password);
    }
    

    [Given(@"the user has opened the item ""(.*)""")]
    public void GivenTheUserHasOpenedTheItem(string itemName)
    {
        _itemPage = _indexPage.ViewItem(itemName);
        
    }

    [When(@"the user has clicks Add to cart ""(.*)"" button")]
    public void WhenTheUserHasClicksAddToCartButton(string itemName)
    {
        _itemPage.AddToCart(itemName);
        _alertText = _itemPage.GetAlert();
    }

    [Then(@"the user gets ""(.*)"" alert")]
    public void ThenTheUserGetsAlert(string expectedAlert)
    {
        _alertText.Should().Be(expectedAlert);
    }
}