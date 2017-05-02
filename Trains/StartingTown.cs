using System.Collections.Generic;

namespace Trains
{
    class StartingTown : Town
    {
        public List<EndingTown> Destinations { get; private set; }
        public StartingTown(char name) : base(name)
        {
            Destinations = new List<EndingTown>();
        }

        public void AddDestination(EndingTown town)
        {
            Destinations.Add(town);
        }
    }
}
