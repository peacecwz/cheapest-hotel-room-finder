using System;
using System.Threading.Tasks;
using HotelBot.Models;

namespace HotelBot.Services
{
    public interface IHotelServices : IDisposable
    {
        Task<HotelRoomModel> GetSingleRoom (DateTime startDate, DateTime endDate);
    }
}