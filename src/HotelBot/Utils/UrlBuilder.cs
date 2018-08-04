namespace HotelBot.Utils
{
    public class UrlBuilder : IUrlBuilder
    {
        public string GenerateUrl(string hotelName, string startDate, string endDate, int guestCount)
        {
            return
                "http://www.tendahotelbodrum.com/" +
                $"rezervasyon/fiyat_hesapla?satis_tarihi={startDate}&child3age[]=0&market=1&hotel_name={hotelName.Replace(" ","+")}&hotel_code=267&supplier_code=&supplier_destination=&destination_name=&destination_code=&hpro_destination_code=&Destination_Type=&numberofroom=1&output=&giris_tarihi={startDate}&cikis_tarihi={endDate}&yetiskin={guestCount}";
        }
    }
}
