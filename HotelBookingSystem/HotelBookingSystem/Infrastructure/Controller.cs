namespace HotelBookingSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using HotelBookingSystem.Identity;
    using HotelBookingSystem.Interfaces;
    using HotelBookingSystem.Models;
    using HotelBookingSystem.Utilities;
    using HotelBookingSystem.Views.Shared;

    public abstract class Controller
    {
        protected Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Currently loggedin user.
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Checks if there is a currently loggedin user.
        /// </summary>
        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IHotelBookingSystemData Data { get; private set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            //Namespace separator was not correct
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamespaceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        protected void Authorize(params Roles[] roles)
        {
            if (!HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException("The currently logged in user doesn't have sufficient rights to perform this operation.");
            }
        }
    }
}
