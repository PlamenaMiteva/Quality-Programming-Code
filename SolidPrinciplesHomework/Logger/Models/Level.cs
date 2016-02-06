using System;

namespace Logger.Models
{
    public class Level
    {
        private string name;

        public Level(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or whitespace.");
                }

                this.name = value;
            }
        }
    }
}
