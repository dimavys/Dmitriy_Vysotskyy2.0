using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class CreateUserSteps : FeatureHelper
{
    private TestUserModel _user;
    private string _alertText;
    
    [Given(@"a user has come to clicked sign up")]
    public void GivenAUserHasComeToClickedSignUp()
    {
        
    }

    [Given(@"a user doesn't have valid data")]
    public void GivenAUserDoesntHaveValidData()
    {
        _user = new TestUserModel();
    }

    [When(@"user inserts that data")]
    public void WhenUserInsertsThatData()
    {
        _alertText = _homePage.SignUp(_user.Login,_user.Password);
    }
    

    [Given(@"a user has valid data")]
    public void GivenAUserHasValidData()
    {
        _user = new TestUserModel();
        _user.MixUserData();
    }

    [Then(@"user gets ""(.*)"" alert")]
    public void ThenUserGetsAlert(string expectedAlert)
    {
        _alertText.Should().Be(expectedAlert);
    }

    [Then(@"close the browser")]
    public void ThenCloseTheBrowser()
    {
        _driver.Quit();
    }
}