using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class LogInSteps : FeatureHelper
{
    [Given(@"an existing user has logged in")]
    [Given(@"a user has logged in")]
    [Given(@"user logged in")]
    public void GivenAnExistingUserHasLoggedIn()
    {
        var user = new UserModelBuilder()
            .SetLogin("charles")
            .SetPassword("charles")
            .Build();
        _indexPage = _homePage.LogIn(user.Login, user.Password);
    }
}