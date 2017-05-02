

using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Trains
{
    public class RoutesVisitor
    {
        private static Dictionary<string, int> routesResult;

        public static Tuple<int, string> SumRouteDistance(char[] townToName, List<StartingTown> townsFrom)
        {
            var message = string.Empty;
            var distance = 0;
            var townFrom = townsFrom.Find(n => n.Name == townToName[0]);
            for (int i = 1; i < townToName.Length; i++)
            {
                if (townFrom == null)
                {
                    message = "NO SUCH ROUTE";
                    break;
                }

                var townTo = FindTownTo(townToName[i], townFrom);

                if (townTo == null)
                {
                    message = "NO SUCH ROUTE";
                    break;
                }

                distance += townTo.Edge;
                townFrom = townTo.Intersection;
            }

            return Tuple.Create<int, string>(distance, message);
        }

        private static EndingTown FindTownTo(char townToName, StartingTown townFrom)
        {
            return townFrom.Destinations.Find(n => n.Name == townToName);
        }

        public static int CountMaxStopRoutes(List<StartingTown> townsFrom, char townFromName, char townToName, bool exactMaxStop, int maxStop)
        {
            routesResult = new Dictionary<string, int>();
            var numberOfRoutes = 0;

            StartingTown townFrom = townsFrom.Find(n => n.Name == townFromName);
            if (townFrom != null)
            {
                FindMaxLengthRoutes(townFrom, null, maxStop + 1);
                
                if (routesResult != null && routesResult.Count > 0)
                {
                    foreach (var route in routesResult.Keys)
                    {
                        if (exactMaxStop)
                        {
                            if (route.Length == maxStop + 1 && route[route.Length - 1] == townToName)
                                numberOfRoutes++;
                        }
                        else
                        {
                            if (route.Length <= maxStop + 1 && route[route.Length - 1] == townToName)
                                numberOfRoutes++;
                        }

                        //Console.WriteLine(string.Format("{0,-10}{1}", route, routesResult[route]));
                    }
                }
            }

            return numberOfRoutes;
        }

        private static void FindMaxLengthRoutes(StartingTown nextTownFrom, string fullRoute, int maxLength)
        {
            foreach (EndingTown townTo in nextTownFrom.Destinations)
            {
                var nextRoute = $"{nextTownFrom.Name}{townTo.Name}";

                var nextFullRoute = string.Empty;

                if (fullRoute == null)
                    nextFullRoute = nextRoute;
                else
                    nextFullRoute = $"{fullRoute}{townTo.Name}";

                if (!string.IsNullOrEmpty(fullRoute))
                {
                    if (routesResult.ContainsKey(fullRoute))
                    {
                        var previousRouteDistance = routesResult[fullRoute];
                        var nextRouteDistance = previousRouteDistance + townTo.Edge;

                        if (routesResult.ContainsKey(nextFullRoute) || nextFullRoute.Length > maxLength)
                            return;

                        routesResult.Add(nextFullRoute, nextRouteDistance);
                    }
                }
                else
                    routesResult.Add(nextRoute, townTo.Edge);

                if (townTo.Intersection == null)
                    return;
                FindMaxLengthRoutes(townTo.Intersection, nextFullRoute, maxLength);
            }
        }

        public static int GetShortestRouteDistance(List<StartingTown> townsFrom, char townFromName, char townToName)
        {
            routesResult = new Dictionary<string, int>();

            StartingTown townFrom = townsFrom.Find(n => n.Name == townFromName);
            int shortestDistance = 0;
            if (townFrom != null)
            {
                FindShortestRoutes(townFrom, null, townToName, null, null);

                if (routesResult != null && routesResult.Count > 0)
                {
                    foreach (var routeFound in routesResult.Keys)
                    {
                        //Console.WriteLine(routeFound);
                        if (routeFound[routeFound.Length - 1] == townToName)
                        {
                            if (routesResult[routeFound] < shortestDistance || shortestDistance == 0)
                                shortestDistance = routesResult[routeFound];
                        }
                    }
                }
            }

            return shortestDistance;
        }

        private static void FindShortestRoutes(StartingTown nextTownFrom, string fullRoute, char townToName, string previousRoute, string previousPreviousRoute)
        {
            foreach (EndingTown townTo in nextTownFrom.Destinations)
            {
                var nextRoute = $"{nextTownFrom.Name}{townTo.Name}";

                var nextFullRoute = string.Empty;

                if (fullRoute == null)
                    nextFullRoute = nextRoute;
                else
                    nextFullRoute = $"{fullRoute}{townTo.Name}";

                if (!string.IsNullOrEmpty(fullRoute))
                {
                    if (routesResult.ContainsKey(fullRoute))
                    {
                        var previousRouteDistance = routesResult[fullRoute];
                        var nextRouteDistance = previousRouteDistance + townTo.Edge;

                        if (routesResult.ContainsKey(nextFullRoute) || previousPreviousRoute == nextRoute)
                            return;

                        routesResult.Add(nextFullRoute, nextRouteDistance);

                        if (townTo.Name == townToName)
                            return;
                    }
                }
                else
                    routesResult.Add(nextRoute, townTo.Edge);

                if (townTo.Intersection == null)
                    return;

                FindShortestRoutes(townTo.Intersection, nextFullRoute, townToName, nextRoute, previousRoute);
            }
        }

        public static int CountMaxDistanceRoutes(List<StartingTown> townsFrom, char townFromName, char townToName, int maxDistance)
        {
            routesResult = new Dictionary<string, int>();

            StartingTown townFrom = townsFrom.Find(n => n.Name == townFromName);
            int countRoutes = 0;
            if (townFrom != null)
            {
                FindMaxDistanceRoutes(townFrom, null, maxDistance);
                if (routesResult != null && routesResult.Count > 0)
                {
                    foreach (var routeFound in routesResult.Keys)
                    {
                        //Console.WriteLine(string.Format("{0,-10}{1}", routeFound, routesResult[routeFound]));
                        if (routeFound[routeFound.Length - 1] == townToName)
                            countRoutes++;
                    }
                }
            }

            return countRoutes;
        }

        private static void FindMaxDistanceRoutes(StartingTown nextTownFrom, string fullRoute, int maxDistance)
        {
            foreach (EndingTown townTo in nextTownFrom.Destinations)
            {
                var nextRoute = $"{nextTownFrom.Name}{townTo.Name}";

                var nextFullRoute = string.Empty;

                if (fullRoute == null)
                    nextFullRoute = nextRoute;
                else
                    nextFullRoute = $"{fullRoute}{townTo.Name}";

                if (!string.IsNullOrEmpty(fullRoute))
                {
                    if (routesResult.ContainsKey(fullRoute))
                    {
                        var previousRouteDistance = routesResult[fullRoute];
                        var nextRouteDistance = previousRouteDistance + townTo.Edge;

                        if (routesResult.ContainsKey(nextFullRoute) || nextRouteDistance >= maxDistance)
                            return;

                        routesResult.Add(nextFullRoute, nextRouteDistance);
                    }
                }
                else
                    routesResult.Add(nextRoute, townTo.Edge);

                if (townTo.Intersection == null)
                    return;

                FindMaxDistanceRoutes(townTo.Intersection, nextFullRoute, maxDistance);
            }
        }

    }
}
