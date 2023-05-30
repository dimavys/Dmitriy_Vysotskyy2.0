using System.Text.Json.Serialization;
using RestSharp;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Tests;

public class Tests
{
    private RestApiClient _restClient;
    private int _id;

    [SetUp]
    public async Task Setup()
    {
        _restClient = new RestApiClient();
        await _restClient.Authenticate("admin", "password123");
    }

    [Test, Order(1)]
    public async Task CreateBooking()
    {
        var dates = new Bookingdates 
        { 
            checkin = DateOnly.Parse("2018-01-01"),
            checkout = DateOnly.Parse("2019-01-01") 
        };
        
        var meta = new BookingMetaData
        {
            firstname = "Charles",
            lastname = "Leclerc",
            totalprice = 12,
            depositpaid = true,
            bookingdates = dates,
            additionalneeds = "empty"
        };
        
        var response = await _restClient.CreateBooking(meta);

        _id = response.Data.bookingid;
        
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Test, Order(2)]
    public async Task UpdateBooking()
    {
        var dates = new Bookingdates 
        { 
            checkin = DateOnly.Parse("2018-01-01"),
            checkout = DateOnly.Parse("2019-01-01") 
        };
        
        var meta = new BookingMetaData
        {
            firstname = "Lewis",
            lastname = "Hamilton",
            totalprice = 12,
            depositpaid = true,
            bookingdates = dates,
            additionalneeds = "empty"
        };

        var data = new BookingMetaDataExtended()
        {
            bookingid = _id,
            booking = meta
        };

        var response = await _restClient.UpdateBooking(data);
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

    }

    [Test, Order(3)]
    public async Task DeleteBooking()
    {
        var response = await _restClient.DeleteBooking(_id);
        Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    
    [TearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }
}