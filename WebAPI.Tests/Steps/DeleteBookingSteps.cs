using System.Net;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Tests.Features;

namespace WebAPI.Tests;

[Binding]
public class DeleteBookingSteps : FeatureHelper
{
    private int _id;
    private RestResponse _deleteResponse;

    [Given(@"a user has specified id")]
    public void GivenAUserHasSpecifiedId()
    {
        _id = _postResponse.Data.Bookingid;
    }

    [When(@"user executes delete request")]
    public async Task WhenUserExecutesDeleteRequest()
    {
        _deleteResponse = await _restApiClient.DeleteBooking(_id);
    }

    [Then(@"he receives 201 Created status code")]
    public void ThenHeReceivesCreatedStatusCode()
    {
        _deleteResponse.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Then(@"he receives 405 Method not allowed status code")]
    public void ThenHeReceivesMethodNotAllowedStatusCode()
    {
        _deleteResponse.StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
    }

    [Given(@"a user has specified invalid id")]
    public void GivenAUserHasSpecifiedInvalidId()
    {
        _id = 11111;
    }

    [Then(@"Booking Id must not be present among the others")]
    public async Task ThenBookingIdMustNotBePresentAmongTheOthers()
    {
        var listBookingIds = await _restApiClient.GetBookingIds();
        listBookingIds.Data
            .FirstOrDefault(b => b.BookingId == _id)
            .Should().BeNull();
    }
}