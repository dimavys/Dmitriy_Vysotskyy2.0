namespace WebAPI.Infrastructure.RequestsResponses;

public class BookingMetaData
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Totalprice { get; set; }
    public bool Depositpaid { get; set; }
    public Bookingdates Bookingdates { get; set; }
    public string Additionalneeds { get; set; }
}