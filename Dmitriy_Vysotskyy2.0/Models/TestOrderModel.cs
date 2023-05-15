namespace Dmitriy_Vysotskyy2._0.Models;

public class TestOrderModel
{
    public string Name { get; }
    public string Country { get; }
    public string City { get; }
    public string Card { get; }
    public string Month { get; }
    public string Year { get; }
    
    public TestOrderModel()
    {
        Name = "TestName";
        Country = "Ukraine";
        City = "Kyiv";
        Card = "122";
        Month = "5";
        Year = "2023";
    }
}