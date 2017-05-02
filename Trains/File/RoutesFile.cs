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

        public string[] GetGraphElements()
        {
            string graph = routesFile.ReadToEnd().Replace("Graph:", "").Replace(" ", "");
            routesFile.Close();
            routesFile.Dispose();

            return graph.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
