using System.Text;
using Dmitriy_Vysotskyy2._0.Models;

namespace Dmitriy_Vysotskyy2._0.Builders;

public class UserModelBuilder
{
    private TestUserModel _userModel = new TestUserModel();

    public UserModelBuilder SetRandomData()
    {
        _userModel.Login = generateRandomData();
        _userModel.Password = generateRandomData();
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
    
    private string generateRandomData()
    {
        int length = 10;
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder sb = new StringBuilder();

        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            char c = chars[index];
            sb.Append(c);
        }

        return sb.ToString();
    }
}