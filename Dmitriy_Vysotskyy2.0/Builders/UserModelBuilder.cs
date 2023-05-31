using Dmitriy_Vysotskyy2._0.Models;

namespace Dmitriy_Vysotskyy2._0.Builders;

public class UserModelBuilder
{
    private TestUserModel _userModel = new TestUserModel();

    public UserModelBuilder SetRandomData()
    {
        _userModel.Login = StringExtensions.GenerateRandomData();
        _userModel.Password = StringExtensions.GenerateRandomData();
        return this;
    }

    public UserModelBuilder SetLogin(string login)
    {
        _userModel.Login = login;
        return this;
    }
    
    public UserModelBuilder SetPassword(string password)
    {
        _userModel.Password = password;
        return this;
    }

    public TestUserModel Build()
    {
        return _userModel;
    }
}