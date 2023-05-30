using Dmitriy_Vysotskyy2._0.Models;

namespace Dmitriy_Vysotskyy2._0.Builders;

public class OrderModelBuilder
{
    private TestOrderModel _orderModel = new TestOrderModel();

    public OrderModelBuilder SetName(string name)
    {
        _orderModel.Name = name;
        return this;
    }
    
    public OrderModelBuilder SetCountry(string country)
    {
        _orderModel.Country = country;
        return this;
    }
    
    public OrderModelBuilder SetCity(string city)
    {
        _orderModel.City = city;
        return this;
    }
    
    public OrderModelBuilder SetCard(string card)
    {
        _orderModel.Card = card;
        return this;
    }
    
    public OrderModelBuilder SetMonth(string month)
    {
        _orderModel.Month = month;
        return this;
    }
    
    public OrderModelBuilder SetYear(string year)
    {
        _orderModel.Year = year;
        return this;
    }

    public TestOrderModel Build()
    {
        return _orderModel;
    }
}