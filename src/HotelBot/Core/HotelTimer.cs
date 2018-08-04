using System;
using System.Threading;
using HotelBot.Services;

namespace HotelBot.Core
{
    public class HotelTimer : IDisposable
    {
        private readonly Timer _timer;
        private readonly IHotelServices _hotelServices;
        public HotelTimer (IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;
            _timer = new Timer(CheckSingleRoom, null, TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(1));
        }

        public async void CheckSingleRoom (object state)
        {
            Console.WriteLine();
            Console.WriteLine("Looking available single rooms");
            Console.WriteLine();
            var singleRoom = await _hotelServices.GetSingleRoom(DateTime.Parse("08-08-2018"), DateTime.Parse("10-08-2018"));
            if (singleRoom != null)
            {
                Console.WriteLine("Found single room");
                Console.WriteLine($"Room Name: {singleRoom.Name}");
                Console.WriteLine($"Price: {singleRoom.Price} TRY");
                Console.WriteLine();

                Console.Beep();
            }
        }

        public void Start()
        {
            _timer.InitializeLifetimeService();
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _hotelServices?.Dispose();
        }
    }
}
