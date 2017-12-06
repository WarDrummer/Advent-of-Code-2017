namespace AdventOfCode2017.Solutions
{
    using System.Text;

    public class SingleLineStringParser : InputParser<string>
    {
        public SingleLineStringParser(string inputFile) : base(inputFile) { }

        public override string GetData()
        {
            var sb = new StringBuilder();
            foreach (var line in GetInput())
            {
                sb.Append(line);
            }
            return sb.ToString();
        }
    }
}