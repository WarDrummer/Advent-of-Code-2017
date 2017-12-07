using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Solutions.Parsers
{
    public abstract class InputParser<T> : IInputParser<T>
    {
        private readonly string _inputFile;

        protected InputParser(string inputFile)
        {
            _inputFile = inputFile;
        }

        protected IEnumerable<string> GetInput()
        {
            using (var sr = new StreamReader(_inputFile))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }

        public abstract T GetData();
    }
}