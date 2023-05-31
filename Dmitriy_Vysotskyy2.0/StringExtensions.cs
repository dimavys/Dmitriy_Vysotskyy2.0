using System.Text;

namespace Dmitriy_Vysotskyy2._0;

public static class StringExtensions
{
    public static string GenerateRandomData()
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