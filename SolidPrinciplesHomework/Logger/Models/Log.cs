using System;
using Logger.Interfaces;

namespace Logger.Models
{
   public class Log : ILog
   {
       private Level level;
       private string message;

       public Log(Level level, string message)
       {
           this.LogDate = DateTime.Now;
           this.Level = level;
           this.Message = message;
       }

       public DateTime LogDate { get; private set; }

       public Level Level
       {
           get { return this.level; }

           set
           {
               if (value == null)
               {
                   throw new ArgumentNullException("Level cannot be null.");
               }

               this.level = value;
           }
       }

       public string Message
       {
           get { return this.message; }

           set
           {
               if (String.IsNullOrWhiteSpace(value))
               {
                   throw new ArgumentNullException("Message cannot be null or whitespace.");
               }

               this.message = value;
           }
       }
    }
}
