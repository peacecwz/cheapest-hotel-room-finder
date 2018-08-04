using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBot.Models;

namespace HotelBot.Core
{
    public interface IHotelCrawler : IDisposable
    {
        Task<List<HotelRoomModel>> GetAvailableRooms (string url);
    }
}