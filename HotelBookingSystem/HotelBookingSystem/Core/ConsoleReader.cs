namespace HotelBookingSystem.Core
{
    using System;
    using HotelBookingSystem.Interfaces;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
