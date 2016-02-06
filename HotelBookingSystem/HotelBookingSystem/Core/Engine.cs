namespace HotelBookingSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Infrastructure;
    using HotelBookingSystem.Interfaces;
    using HotelBookingSystem.Models;
    using HotelBookingSystem.Utilities;
    using HotelBookingSystem.Views.Shared;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IHotelBookingSystemData data;

        public Engine(IHotelBookingSystemData data, IReader reader, IWriter writer)
        {
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            User currentUser = null;
            while (true)
            {
                string url = this.reader.Read();
                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);

                var controller = Activator.CreateInstance(controllerType, this.data, currentUser) as Controller;
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                writer.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    //decimal type added
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(executionEndpoint.Parameters[p.Name], Constants.DateFormat, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return executionEndpoint.Parameters[p.Name];
                    }
                })
               .ToArray();

            return parameters;
        }
    }
}
