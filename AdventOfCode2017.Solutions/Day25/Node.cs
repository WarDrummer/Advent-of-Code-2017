namespace AdventOfCode2017.Solutions.Day25
{
    public class Node<T>
    {
        public Node<T> Right { get; set; }

        public Node<T> Left { get; set; }
        
        public T Value { get; set; }
    }
}