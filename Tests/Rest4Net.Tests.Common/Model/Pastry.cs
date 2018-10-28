namespace Rest4Net.Test.Common.Model
{
    public class Pastry
    {
        public Pastry(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        public int Count { get; }
    }
}
