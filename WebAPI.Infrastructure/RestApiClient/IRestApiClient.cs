using RestSharp;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Infrastructure;

public interface IRestApiClient
{
    Task<RestResponse<BookingMetaDataExtended>> CreateBooking(BookingMetaData testData);
    Task<RestResponse> DeleteBooking(int id);
    Task<RestResponse<BookingMetaData>> UpdateBooking(BookingMetaDataExtended data);
    Task<RestResponse<List<Booking>>> GetBookingIds();
    Task<RestResponse<BookingMetaData>> GetBookingById(int id);
    void Dispose();
}