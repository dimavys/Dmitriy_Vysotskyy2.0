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

    [Test, Order(0)]
    public async Task CreateBooking()
    {
        var data = new BookingMetaData
        {
            firstname = "Valteri",
            lastname = "Bottas",
            totalprice = 111,
            depositpaid = true,
            bookingdates = new Bookingdates
            {
                checkin = DateOnly.Parse("2018-01-01"),
                checkout = DateOnly.Parse("2019-01-01")
            },
            additionalneeds = "super bowls"
        };
    
        var response = await _restClient.CreateBooking(data);
        
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        
        _id = response.Data.bookingid;
    }

    [Test, Order(1)]
    public async Task UpdateBooking()
    {
        var data = new BookingMetaDataExtended
        {
            bookingid = 2637,
            booking = new BookingMetaData
            {
                firstname = "Lewis",
                lastname = "Hamilton",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new Bookingdates
                {
                    checkin = DateOnly.Parse("2018-01-01"),
                    checkout = DateOnly.Parse("2019-01-01")
                },
                additionalneeds = "super bowls"
            }
        };
        
        var response = await _restClient.UpdateBooking(data);
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    
    }

    // [Test, Order(3)]
    // public async Task DeleteBooking()
    // {
    //     var response = await _restClient.DeleteBooking(_id);
    //     Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
    // }

    [TearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }
}
