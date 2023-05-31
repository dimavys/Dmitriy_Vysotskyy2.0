using Dmitriy_Vysotskyy2._0.Common;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class OrderCommonSteps : FeatureHelper
{
    [Given(@"user has added ""(.*)"" to cart")]
    [Given(@"user added ""(.*)"" to cart")]
    public void GivenUserHasAddedToCart(string itemName)
    {
        _itemPage = _indexPage.ViewItem(itemName);
        _itemPage.AddToCart(itemName);
    }
}