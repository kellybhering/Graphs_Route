namespace Trains
{
    abstract class Town
    {
        public char Name { get; private set; }
        public Town(char name)
        {
            this.Name = name;
        }        
    }
}
