using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Infrastructure;

public class RestApiClient 
{
    private RestClient _client;
    private string _token;

    public RestApiClient()
    {
        _client = new RestClient(RestClientConfig.ClientUrl);
    }
   
    
    public async Task Authenticate(string username, string password)
    {
        var request = RequestService.BuildAuthRequest(username, password);
            
        var response = await _client.ExecutePostAsync<AuthenticationResponse>(request);

        _token = response.Data?.token;
    }

    public async Task<RestResponse<BookingMetaDataExtended>> CreateBooking(BookingMetaData testData)
    {
        var request = RequestService.BuildPostRequest(testData);

        var response = await _client.ExecutePostAsync<BookingMetaDataExtended>(request);

        return response;
    }

    public async Task<RestResponse> DeleteBooking(int id)
    {
        var request = RequestService.BuildDeleteRequest(id, _token);
        
        var response = await _client.ExecuteAsync(request);

        return response;
    }
    
    public async Task <RestResponse<BookingMetaData>> UpdateBooking(BookingMetaDataExtended data)
    {
        var request = RequestService.BuildUpdateRequest(data, _token);

        var response = await _client.ExecutePutAsync<BookingMetaData>(request);

        return response;
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}