using System;
using System.IO;

namespace Trains
{
    class RoutesFile
    {
        private StreamReader routesFile;
        public RoutesFile(string routesFilePath)
        {
            routesFile = new StreamReader(routesFilePath);            
        }

        public string ReadLine()
        {
            try
            {
                string line;
                line = routesFile.ReadLine();

                if (line == null)
                {
                    routesFile.Close();
                    routesFile.Dispose();
                }

                return line;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
