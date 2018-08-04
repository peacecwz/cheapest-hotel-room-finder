using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelBot.Models;
using HtmlAgilityPack;

namespace HotelBot.Core
{
    public class HotelCrawler : IHotelCrawler
    {
        private readonly HtmlDocument _document;
        private readonly HttpClient _client;
        public HotelCrawler ()
        {
            _client = new HttpClient();
            _document = new HtmlDocument();
        }

        ~HotelCrawler ()
        {
            Dispose();
        }

        public async Task<List<HotelRoomModel>> GetAvailableRooms (string url)
        {
            var rooms = new List<HotelRoomModel>();
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response?.Content.ReadAsStringAsync();
                string html = $"<html><head></head><body>{content}</body></html>";
                _document.Load(html);
                var roomDivs = _document.DocumentNode.SelectNodes(@".//div[@class='hotel-price home']");
                foreach (var roomDiv in roomDivs)
                {
                    var room = new HotelRoomModel()
                    {
                        Name = roomDiv.SelectSingleNode(".//h3[class='visible-xs']").InnerText.Trim(),
                        GuestCount = roomDiv.SelectNodes(".//strong").Count,
                        Price = decimal.Parse(roomDiv.SelectSingleNode(".//small[@class='text-line-through']").InnerText.Trim())
                    };
                    rooms.Add(room);
                }
            }

            return rooms;
        }

        public void Dispose ()
        {
            _client?.Dispose();
            if (_document != null)
            {
                GC.SuppressFinalize(_document);
            }
        }
    }
}
