using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day08
{
    using ParserType = MultiLineStringParser;

    internal class Day8A : IProblem
    {
        protected Dictionary<string, int> Registers = new Dictionary<string, int>();
        protected readonly ParserType _parser;

        public Day8A(ParserType parser) { _parser = parser; }

        public Day8A() : this(new ParserType("Day08\\day8.in")) { }

        public virtual string Solve()
        {
            foreach (var line in _parser.GetData().ToArray())
            {
                var parts = line.Split(' ');

                var commandRegister = parts[0];
                var command = parts[1];
                var commandValue = int.Parse(parts[2]);
                var evalRegister = parts[4];
                var evalOperator = parts[5];
                var evalValue = int.Parse(parts[6]);

                if (!Registers.ContainsKey(commandRegister))
                    Registers[commandRegister] = 0;

                if (!Registers.ContainsKey(evalRegister))
                    Registers[evalRegister] = 0;

                if (EvaluateCondition(evalRegister, evalOperator, evalValue))
                    UpdateRegister(commandRegister, command, commandValue);
            }

            return Registers.Values.Max().ToString();
        }

        protected void UpdateRegister(string register, string op, int value)
        {
            switch (op)
            {
                case "inc":
                    Registers[register] += value;
                    break;
                case "dec":
                    Registers[register] -= value;
                    break;
                default:
                    throw new Exception($"Unknown command: {op}");
            }
        }

        protected bool EvaluateCondition(string register, string op, int value)
        {
            switch (op)
            {
                case "<": return Registers[register] < value;
                case ">": return Registers[register] > value;
                case "<=": return Registers[register] <= value;
                case ">=": return Registers[register] >= value;
                case "==": return Registers[register] == value;
                case "!=": return Registers[register] != value;
                default: throw new Exception($"Unknown op: {op}");
            }
        }
    }
}
