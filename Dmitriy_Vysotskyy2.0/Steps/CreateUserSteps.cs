using Dmitriy_Vysotskyy2._0.Builders;
using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Steps;

[Binding]
public class CreateUserSteps 
{
    private TestUserModel _user;
    private string _alertText;

    [Given(@"valid data for login has been prepared")]
    public void GivenValidDataForLoginHasBeenPrepared()
    {
        _user = new UserModelBuilder()
            .SetRandomData()
            .Build();
    }

    [Given(@"invalid data for login has been prepared")]
    public void GivenInvalidDataForLoginHasBeenPrepared()
    {
        _user = new UserModelBuilder()
            .SetLogin("charles")
            .SetPassword("charles")
            .Build();
    }

    [When(@"user fills signup popup with data")]
    public void WhenUserFillsSignupPopupWithData()
    {
        _alertText = FeatureHelper.HomePage.SignUp(_user.Login,_user.Password);
    }
    
    [Then(@"user gets ""(.*)"" alert")]
    public void ThenUserGetsAlert(string expectedAlert)
    {
        _alertText.Should().Be(expectedAlert);
    }
}