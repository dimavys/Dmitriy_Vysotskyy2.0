using System.Net;
using FluentAssertions;
using TechTalk.SpecFlow;
using WebAPI.Infrastructure.Builder;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Tests.Features;

namespace WebAPI.Tests;

[Binding]
public class CreateBookingSteps : FeatureHelper
{
    [Given(@"valid data for post has been prepared")]
    public void GivenValidDataForPostHasBeenPrepared()
    {
        _metaData = new MetaDataBuilder()
            .SetFirstName("Lando")
            .SetLastName("Norris")
            .SetPrice(111)
            .SetDepositPaidStatus(true)
            .SetBookingDates(new Bookingdates
            {
                Checkin = DateOnly.Parse("2018-01-01"),
                Checkout = DateOnly.Parse("2019-01-01")
            })
            .SetAdditionalNeeds("super bowls")
            .Build();
    }
    
    [Given(@"invalid data for post has been prepared")]
    public void GivenInvalidDataForPostHasBeenPrepared()
    {
        _metaData = new MetaDataBuilder()
            .SetFirstName("Lando")
            .SetLastName("Norris")
            .SetPrice(111)
            .SetDepositPaidStatus(true)
            .SetAdditionalNeeds("super bowls")
            .Build();
    }
    
    [Then(@"he gets valid response")]
    public void ThenHeGetsValidResponse()
    {
        _postResponse.Data.Booking.Lastname.Should().Be(_metaData.Lastname); 
    }
    
    [Then(@"he receives 500 Internal server error code")]
    public void ThenHeReceivesInternalServerErrorCode()
    {
        _postResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Then(@"bookingId must be present among others")]
    public async Task ThenBookingIdMustBePresentAmongOthers()
    {
        var listBookingIds = await _restApiClient.GetBookingIds();
        listBookingIds.Data
            .FirstOrDefault(b => b.BookingId == _postResponse.Data.Bookingid)
            .Should().NotBeNull();
        
    }

    [Then(@"get booking by id data must be equal to created post data")]
    public async Task ThenGetBookingByIdDataMustBeEqualToCreatedPostData()
    {
        var getResponse = await _restApiClient.GetBookingById(_postResponse.Data.Bookingid);
        getResponse.Data.Should().BeEquivalentTo(_metaData);
    }
}