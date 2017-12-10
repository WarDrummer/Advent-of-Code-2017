namespace AdventOfCode2017.Solutions
{
    public class Node<TValue>
    {
        public TValue Value { get; set; }
        public Node<TValue> Next { get; set; }
    }
}