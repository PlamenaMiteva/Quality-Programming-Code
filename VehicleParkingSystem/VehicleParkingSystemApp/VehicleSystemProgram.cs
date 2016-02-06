namespace VehicleParkingSystemApp
{
    using System.Globalization;
    using System.Threading;
    using Core;

    public class VehicleSystemProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}
