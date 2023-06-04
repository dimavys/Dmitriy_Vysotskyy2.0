using WebAPI.Infrastructure.RequestsResponses;

namespace WebAPI.Infrastructure.Builder;

public class MetaDataBuilder
{
    private BookingMetaData _metaData = new BookingMetaData();

    public MetaDataBuilder SetFirstName(string firstName)
    {
        _metaData.Firstname = firstName;
        return this;
    }
    
    public MetaDataBuilder SetLastName(string lastName)
    {
        _metaData.Lastname = lastName;
        return this;
    }
    
    public MetaDataBuilder SetPrice(int price)
    {
        _metaData.Totalprice = price;
        return this;
    }
    
    public MetaDataBuilder SetDepositPaidStatus(bool value)
    {
        _metaData.Depositpaid = value;
        return this;
    }
    
    public MetaDataBuilder SetBookingDates(Bookingdates bookingdates)
    {
        _metaData.Bookingdates = bookingdates;
        return this;
    }
    
    public MetaDataBuilder SetAdditionalNeeds(string additionalNeeds)
    {
        _metaData.Additionalneeds = additionalNeeds;
        return this;
    }

    public BookingMetaData Build()
    {
        return _metaData;
    }
}