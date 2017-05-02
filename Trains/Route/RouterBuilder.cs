using System;
using System.Collections.Generic;

namespace Trains
{
    public class RouterBuilder
    {
        private RoutesFile routesFile;
        public RouterBuilder(string routesFilePath)
        {
            routesFile = new RoutesFile(routesFilePath);
        }

        public List<StartingTown> Build()
        {
            var startingTowns = new List<StartingTown>();
            List<EndingTown> endingTowns = new List<EndingTown>();
            var graphElements = routesFile.GetGraphElements();

            foreach (var nodeEdge in graphElements)
            {
                if (nodeEdge[0] == nodeEdge[1])
                    continue;

                var startingTown = startingTowns.Find(n => n.Name == nodeEdge[0]);
                if (startingTown == null)
                {
                    startingTown = new StartingTown(nodeEdge[0]);
                    startingTowns.Add(startingTown);
                }

                if (startingTown.Destinations.Find(n => n.Name == nodeEdge[1]) == null)
                {
                    var endingTown = new EndingTown(nodeEdge[1], int.Parse(nodeEdge.Substring(2)));
                    startingTown.AddDestination(endingTown);

                    endingTowns.Add(endingTown);
                }
            }

            //Add intersections
            foreach (var town in startingTowns)
            {
                var intersections = endingTowns.FindAll(n => n.Name == town.Name);
                foreach (var endingTown in intersections)
                    endingTown.AddIntersection(town);
            }

            return startingTowns;
        }
    }
}

