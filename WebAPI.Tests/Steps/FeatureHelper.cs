using RestSharp;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Tests.Features;

public class FeatureHelper
{
    protected static IRestApiClient _restApiClient;
    protected static BookingMetaData _metaData;
    protected static RestResponse<BookingMetaDataExtended> _postResponse;
    protected static RestResponse<BookingMetaData> _putResponse;
}