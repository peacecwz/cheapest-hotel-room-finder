namespace HotelBot.Utils
{
    public interface IUrlBuilder
    {
        string GenerateUrl (string hotelName,string startDate,string endDate,int guestCount);
    }
}
