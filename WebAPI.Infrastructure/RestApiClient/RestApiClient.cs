using RestSharp;
using RestSharp.Authenticators;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Infrastructure;

public class RestApiClient 
{
    private readonly RestClient _client;

    public RestApiClient()
    {
        var options = new RestClientOptions("https://restful-booker.herokuapp.com/auth") {
            Authenticator = new HttpBasicAuthenticator("username", "password")
        };
        
        _client = new RestClient(options);
    }

    public async Task<RestResponse<BookingMetaDataExtended>> CreateBooking(BookingMetaData data)
    {
        var request = RequestService.BuildPostRequest(data);

        var response = await _client.ExecutePostAsync<BookingMetaDataExtended>(request);

        return response;
    }
    
    public async Task DeleteBooking()
    {
        throw new NotImplementedException();
    }
    
    public async Task UpdateBooking()
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}