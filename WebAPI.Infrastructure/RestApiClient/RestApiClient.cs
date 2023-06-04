using RestSharp;
using WebAPI.Infrastructure.RequestsResponses;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Infrastructure;

public class RestApiClient : IRestApiClient, IDisposable
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
        await Authenticate(UserStorage.Login, UserStorage.Password);
        
        var request = RequestService.BuildDeleteRequest(id, _token);
        
        var response = await _client.ExecuteAsync(request);

        return response;
    }
    
    public async Task <RestResponse<BookingMetaData>> UpdateBooking(BookingMetaDataExtended data)
    {
        await Authenticate(UserStorage.Login, UserStorage.Password);

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