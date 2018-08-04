using System;
using System.Linq;
using System.Threading.Tasks;
using HotelBot.Core;
using HotelBot.Models;
using HotelBot.Utils;

namespace HotelBot.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IHotelCrawler _hotelCrawler;
        public HotelServices (IHotelCrawler hotelCrawler, IUrlBuilder urlBuilder)
        {
            _hotelCrawler = hotelCrawler;
            _urlBuilder = urlBuilder;
        }

        public async Task<HotelRoomModel> GetSingleRoom (DateTime startDate, DateTime endDate)
        {
            string url = _urlBuilder.GenerateUrl("Tenda Hotel Bodrum", startDate.ToString("dd-MM-yy"),
                endDate.ToString("dd-MM-yy"), 1);
            var rooms = await _hotelCrawler.GetAvailableRooms(url);
            if (rooms.Any() && rooms.Count(x => x.GuestCount == 1) > 0)
            {
                return rooms.FirstOrDefault(x => x.GuestCount == 1);
            }

            return default(HotelRoomModel);
        }

        public void Dispose ()
        {
            _hotelCrawler?.Dispose();
            if (_urlBuilder != null)
            {
                GC.SuppressFinalize(_urlBuilder);
            }
        }
    }
}
