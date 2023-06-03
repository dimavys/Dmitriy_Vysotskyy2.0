using RestSharp;
using WebAPI.Infrastructure.Builder;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Infrastructure.Services;

public static class RequestService
{
    public static RestRequest BuildAuthRequest(string username, string password)
    {
        var request = new RequestBuilder()
            .SetUrl("/auth")
            .SetHeader("Content-Type", "application/json")
            .SetBody<object>(new { username, password })
            .Build();

        return request;
    }
    public static RestRequest BuildDeleteRequest(int id, string token)
    {
        var request = new RequestBuilder()
            .SetDeleteUrl("/booking/" + id)
            .SetHeader("Content-Type", "application/json")
            .SetHeader("Cookie","token=" + token)
            .Build();
        
        return request;
    }
    
    public static RestRequest BuildPostRequest(BookingMetaData testData)
    {
        var request = new RequestBuilder()
            .SetPostUrl("/booking")
            .SetHeader("Content-Type", "application/json")
            .SetHeader("Accept", "application/json")
            .SetBody(testData)
            .Build();
        
        return request;
    }
    
    public static RestRequest BuildUpdateRequest(BookingMetaDataExtended data, string token)
    {
        var request = new RequestBuilder()
            .SetUpdateUrl("/booking/" + data.bookingid)
            .SetHeader("Content-Type", "application/json")
            .SetHeader("Accept", "application/json")
            .SetHeader("Cookie","token=" + token)
            .SetBody(data.booking)
            .Build();

        return request;
    }
}