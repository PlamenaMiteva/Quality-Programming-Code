using System;
using System.IO;
using Logger.Interfaces;

namespace Logger.Models
{
    class FileAppender : IAppender
    {
        private ILayout layout;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public string LogFile { get; set; }

        public void ExecuteAppendLog(Log log)
        {
            string path = string.Format("../../{0}", this.LogFile);

            try
            {
                if (!File.Exists(path))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
                    {
                        file.WriteLine(layout.Format(log));
                    }
                }
                else if (File.Exists(path))
                {
                    using (TextWriter textWriter = new StreamWriter(path, true))
                    {
                        textWriter.WriteLine(layout.Format(log));
                        textWriter.Close();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

