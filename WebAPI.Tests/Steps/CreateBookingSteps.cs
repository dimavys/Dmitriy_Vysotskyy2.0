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
}