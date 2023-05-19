using WebAPI.Infrastructure;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Tests;

public class Tests
{
    private RestApiClient _restClient;

    [SetUp]
    public void Setup()
    {
        _restClient = new RestApiClient();
    }

    [Test]
    public async Task Test1()
    {
        var dates = new Bookingdates 
        { 
            checkin = "2018-01-01",
            checkout = "2019-01-01" 
        };
        
        var data = new BookingMetaData
        {
            firstname = "Max",
            lastname = "Verstappen",
            totalprice = 600,
            depositpaid = true,
            additionalneeds = "empty",
            bookingdates = dates
        };
        
        var response = await _restClient.CreateBooking(data);
        
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
    
    [TearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }
}