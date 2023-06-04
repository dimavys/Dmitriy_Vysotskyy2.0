using RestSharp;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Infrastructure;

public interface IRestApiClient
{
    Task Authenticate(string username, string password);
    Task<RestResponse<BookingMetaDataExtended>> CreateBooking(BookingMetaData testData);
    Task<RestResponse> DeleteBooking(int id);
    Task<RestResponse<BookingMetaData>> UpdateBooking(BookingMetaDataExtended data);

    void Dispose();
}