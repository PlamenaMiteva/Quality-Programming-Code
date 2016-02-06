using System.Text;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Infrastructure
{
    public abstract class View : IView
    {
        protected View(object model)
        {
            //Model was not properly set
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        protected abstract void BuildViewResult(StringBuilder viewResult);
    }
}
