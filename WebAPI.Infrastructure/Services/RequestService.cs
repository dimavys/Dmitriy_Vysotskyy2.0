using RestSharp;
using WebAPI.Infrastructure.Builder;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Infrastructure.Services;

public static class RequestService
{
    public static RestRequest BuildPostRequest(BookingMetaData bookingMetaData)
    {
        var request = new RequestBuilder()
            .SetUrl("https://restful-booker.herokuapp.com/booking")
            .SetHeader("Content-Type", "application/json")
            .SetBody(bookingMetaData)
            .Build();
        
        return request;
    }

    public static RestRequest BuildDeleteRequest()
    {
        // var request = new RequestBuilder.RequestBuilder()
        //     .SetUrl(RouteConstants.DeleteFileUrl)
        //     .SetHeader("Content-Type", "application/json")
        //     .SetBody<object>(new { path = filePath })
        //     .Build();
        //
        // return request;
        throw new NotImplementedException();
    }
    
    public static RestRequest BuildUpdateRequest()
    {
        // var request = new RequestBuilder.RequestBuilder()
        //     .SetUrl(RouteConstants.DeleteFileUrl)
        //     .SetHeader("Content-Type", "application/json")
        //     .SetBody<object>(new { path = filePath })
        //     .Build();
        //
        // return request;
        throw new NotImplementedException();
    }
}