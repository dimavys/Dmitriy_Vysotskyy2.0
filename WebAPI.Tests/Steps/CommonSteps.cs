using System.Net;
using TechTalk.SpecFlow;
using WebAPI.Tests.Features;
using FluentAssertions;

namespace WebAPI.Tests.Steps;

[Binding]
public class CommonSteps : FeatureHelper
{
    [Given(@"user executes post request")]
    [When(@"user executes post request")]
    public async Task WhenUserExecutesPostRequest()
    {
        _postResponse = await _restApiClient.CreateBooking(_metaData);
    }
    
    [Then(@"he receives 200 OK status code")]
    public void ThenHeReceivesOkStatusCode()
    {
        _postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}