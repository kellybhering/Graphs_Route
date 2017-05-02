using System;
using System.Collections.Generic;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RouterBuilder builder = new RouterBuilder("../Inputs/input.txt");
                var townsFrom = builder.Build();

                var sumDistanceResult = new List<Tuple<int, string>>()
                    {
                        RoutesVisitor.SumRouteDistance(new char[] { 'A', 'B', 'C' }, townsFrom),
                        RoutesVisitor.SumRouteDistance(new char[] { 'A', 'D' }, townsFrom),
                        RoutesVisitor.SumRouteDistance(new char[] { 'A', 'D', 'C' }, townsFrom),
                        RoutesVisitor.SumRouteDistance(new char[] { 'A', 'E', 'B', 'C', 'D'}, townsFrom),
                        RoutesVisitor.SumRouteDistance(new char[] { 'A', 'E', 'D' }, townsFrom)
                    };


                var sumRoutesToTown = new List<int>()
                    {
                        RoutesVisitor.CountMaxStopRoutes(townsFrom, 'C', 'C', false, 3),
                        RoutesVisitor.CountMaxStopRoutes(townsFrom, 'A', 'C', true, 4)
                    };

                var shortestRouteDistance = new List<int>()
                    {
                        RoutesVisitor.GetShortestRouteDistance(townsFrom, 'A', 'C'),
                        RoutesVisitor.GetShortestRouteDistance(townsFrom, 'B', 'B')
                    };

                var sumRoutesToTownMaxDistance = new List<int>()
                    {
                         RoutesVisitor.CountMaxDistanceRoutes(townsFrom, 'C', 'C', 30)
                    };

                int countOutPut = 0;
                for (int i = 0; i < sumDistanceResult.Count; i++)
                {
                    countOutPut++;
                    Console.WriteLine($"Output #{countOutPut}: {(string.IsNullOrEmpty(sumDistanceResult[i].Item2) ? sumDistanceResult[i].Item1.ToString() : sumDistanceResult[i].Item2)}");
                }

                for (int i = 0; i < sumRoutesToTown.Count; i++)
                {
                    countOutPut++;
                    Console.WriteLine($"Output #{countOutPut}: {sumRoutesToTown[i]}");
                }

                for (int i = 0; i < shortestRouteDistance.Count; i++)
                {
                    countOutPut++;
                    Console.WriteLine($"Output #{countOutPut}: {shortestRouteDistance[i]}");
                }

                for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
                {
                    countOutPut++;
                    Console.WriteLine($"Output #{countOutPut}: {sumRoutesToTownMaxDistance[i]}");
                }

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.Write($"Erro na aplicação: {ex.ToString()}");
                Console.Read();
            }
        }
    }
}
