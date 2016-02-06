namespace HotelBookingSystem.Core
{
    using System;
    using HotelBookingSystem.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
