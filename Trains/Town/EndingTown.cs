namespace Trains
{
    public class EndingTown : Town
    {
        public StartingTown Intersection { get; private set; }
        public int Edge { get; private set; }

        public EndingTown(char name, int edge) : base(name)
        {
            this.Edge = edge;
        }

        public void AddIntersection(StartingTown town)
        {
            Intersection = town;
        }
    }
}
