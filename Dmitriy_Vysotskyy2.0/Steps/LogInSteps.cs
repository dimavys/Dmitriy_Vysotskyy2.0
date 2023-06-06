using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class LogInSteps
{
    private readonly ScenarioContext _scenarioContext;
    public LogInSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"an existing user has logged in")]
    [Given(@"a user has logged in")]
    [Given(@"user logged in")]
    public void GivenAnExistingUserHasLoggedIn()
    {
        var user = new UserModelBuilder()
            .SetLogin("charles")
            .SetPassword("charles")
            .Build();
        _scenarioContext.IndexPage = FeatureHelper.HomePage.LogIn(user.Login, user.Password);
    }
}