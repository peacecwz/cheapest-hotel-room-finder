using System;
using HotelBot.Core;
using HotelBot.Services;
using HotelBot.Utils;

namespace HotelBot
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Bot is initializing...");
            //Initializing
            IUrlBuilder urlBuilder = new UrlBuilder();
            IHotelCrawler hotelCrawler = new HotelCrawler();
            IHotelServices hotelServices = new HotelServices(hotelCrawler, urlBuilder);

            Console.WriteLine("Tenda Hotel Bot is running...");
            var timer = new HotelTimer(hotelServices);
            timer.Start();

            Console.ReadKey();
        }
    }
}
