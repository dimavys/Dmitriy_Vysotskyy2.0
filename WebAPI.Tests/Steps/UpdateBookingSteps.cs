using System.Net;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using WebAPI.Infrastructure.Builder;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Tests.Features;

namespace WebAPI.Tests;

[Binding]
public class UpdateBookingSteps : FeatureHelper
{
    private BookingMetaDataExtended _data;
    private RestResponse<BookingMetaData> _putResponse;

    [Given(@"valid data for put has been prepared")]
    public void GivenValidDataForPutHasBeenPrepared()
    {
        _data = new BookingMetaDataExtended
        {
            Bookingid = _postResponse.Data.Bookingid,
            Booking = new MetaDataBuilder()
                .SetFirstName("Max")
                .SetLastName("Verstappen")
                .SetPrice(111)
                .SetDepositPaidStatus(true)
                .SetBookingDates(new Bookingdates
                {
                    Checkin = DateOnly.Parse("2018-01-01"),
                    Checkout = DateOnly.Parse("2019-01-01")
                })
                .SetAdditionalNeeds("super bowls")
                .Build()
        };
    }

    [When(@"he puts his data")]
    public async Task WhenHePutsHisData()
    {
       _putResponse = await _restApiClient.UpdateBooking(_data);
    }

    [Given(@"invalid data for put has been prepared")]
    public void GivenInvalidDataForPutHasBeenPrepared()
    {
        _data = new BookingMetaDataExtended
        {
            Bookingid = _postResponse.Data.Bookingid,
            Booking = new MetaDataBuilder()
                .SetFirstName("Max")
                .SetLastName("Verstappen")
                .SetPrice(111)
                .SetDepositPaidStatus(true)
                .SetAdditionalNeeds("super bowls")
                .Build()
        };
    }

    [Then(@"he receives 400 Bad request status code")]
    public void ThenHeReceivesBadRequestStatusCode()
    {
        _putResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}