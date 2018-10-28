namespace Rest4Net.Test.Common.Model
{
    public class Coffee
    {
        public Coffee(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        public int Count { get; }
    }
}
