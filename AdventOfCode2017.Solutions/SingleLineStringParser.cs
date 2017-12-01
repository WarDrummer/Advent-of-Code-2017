using System.Text;

namespace AdventOfCode2017.Solutions
{
    public class SingleLineStringParser : InputParser<string>
    {
        public SingleLineStringParser(string inputFile) : base(inputFile) { }

        public override string Parse()
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