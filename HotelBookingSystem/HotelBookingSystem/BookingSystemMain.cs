namespace HotelBookingSystem
{
    using HotelBookingSystem.Core;
    using HotelBookingSystem.Data;

    class BookingSystemMain
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var data = new HotelBookingSystemData();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var engine = new Engine(data, reader, writer);
            engine.Run();
        }
    }
}
