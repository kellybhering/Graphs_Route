using System;
using System.Collections.Generic;

namespace Trains
{
    class RouterBuilder
    {
        private RoutesFile routesFile;
        public RouterBuilder(string routesFilePath)
        {
            routesFile = new RoutesFile(routesFilePath);
        }

        public ISet<StartingTown> Build()
        {
            try
            {
                var startingTowns = new HashSet<StartingTown>();
                var endingTowns = new HashSet<EndingTown>();

                while (!string.IsNullOrEmpty(routesFile.ReadLine()))
                {

                }
                return startingTowns;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
