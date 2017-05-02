using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Trains.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, string.Empty),
               Tuple.Create<int, string>(5, string.Empty),
               Tuple.Create<int, string>(13, string.Empty),
               Tuple.Create<int, string>(22, string.Empty),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 2, 3 };

            var shortestRouteDistanceTest = new List<int> { 9, 9 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 7 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod2()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input1.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, string.Empty),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 0, 0 };

            var shortestRouteDistanceTest = new List<int> { 9, 0 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 0 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod3()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input2.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, string.Empty),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 1, 1 };

            var shortestRouteDistanceTest = new List<int> { 9, 9 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 3 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod4()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input3.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, string.Empty),
               Tuple.Create<int, string>(5, string.Empty),
               Tuple.Create<int, string>(13, string.Empty),
               Tuple.Create<int, string>(22, string.Empty),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 2, 3 };

            var shortestRouteDistanceTest = new List<int> { 9, 9 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 7 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod5()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input4.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, string.Empty),
               Tuple.Create<int, string>(5, string.Empty),
               Tuple.Create<int, string>(13, string.Empty),
               Tuple.Create<int, string>(22, string.Empty),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 2, 3 };

            var shortestRouteDistanceTest = new List<int> { 9, 9 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 7 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod6()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input5.txt");
            var townsFrom = builder.Build();

            #region TestsResult
            var sumDistanceResultTest = new List<Tuple<int, string>>()
            {
               Tuple.Create<int, string>(9, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(5, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(13, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(22, "NO SUCH ROUTE"),
               Tuple.Create<int, string>(0, "NO SUCH ROUTE")
            };

            var sumRoutesToTownTest = new List<int>() { 0, 0 };

            var shortestRouteDistanceTest = new List<int> { 0, 0 };

            var sumRoutesToTownMaxDistanceTest = new List<int>() { 0 };

            #endregion

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

            #region Asserts
            for (int i = 0; i < sumDistanceResult.Count; i++)
            {
                if (sumDistanceResultTest[i].Item2 != string.Empty)
                {
                    if (sumDistanceResult[i].Item2 != sumDistanceResultTest[i].Item2)
                        Assert.Fail();
                }
                else if (sumDistanceResult[i].Item1 != sumDistanceResultTest[i].Item1)
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTown.Count; i++)
            {
                if (sumRoutesToTownTest[i] != sumRoutesToTown[i])
                    Assert.Fail();
            }

            for (int i = 0; i < shortestRouteDistance.Count; i++)
            {
                if (shortestRouteDistanceTest[i] != shortestRouteDistance[i])
                    Assert.Fail();
            }

            for (int i = 0; i < sumRoutesToTownMaxDistance.Count; i++)
            {
                if (sumRoutesToTownMaxDistanceTest[i] != sumRoutesToTownMaxDistance[i])
                    Assert.Fail();
            }
            #endregion
        }

        [TestMethod]
        public void TestMethod7()
        {
            RouterBuilder builder = new RouterBuilder("../Inputs/input5.txt");
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
        }
    }
}
