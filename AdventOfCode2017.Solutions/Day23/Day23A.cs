using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day23
{
    using ParserType = MultiLineStringParser;

    internal class Day23A : IProblem
    {
        protected readonly ParserType Parser;

        public Day23A(ParserType parser) { Parser = parser; }

        public Day23A() : this(new ParserType("Day23\\day23.in")) { }

        public virtual string Solve()
        {
            var computer = new Computer(Parser.GetData().ToArray());
            computer.Run();
            return computer.MultiplyCount.ToString();
        }
    }

    internal class Computer
    {
        protected readonly string[][] Instructions;
        protected readonly Dictionary<string, long> Registers = new Dictionary<string, long>();
        protected long InstructionPtr;
        public bool StackOverflow => InstructionPtr >= Instructions.Length || InstructionPtr < 0;
        public int MultiplyCount { get; set; }

        public Computer(IEnumerable<string> instructions)
        {
            Instructions = instructions.Select(i => i.Split(' ').ToArray()).ToArray();
        }

        public virtual bool Terminate { get; set; }

        public void Run()
        {
            while (!StackOverflow && !Terminate)
                ExecuteCycle();
        }

        public virtual void ExecuteCycle()
        {
            var parts = Instructions[InstructionPtr];
            switch (parts[0])
            {
                case "set":
                    Set(parts);
                    break;
                case "sub":
                    Sub(parts);
                    break;
                case "mul":
                    MultiplyCount++;
                    Mul(parts);
                    break;
                case "jnz":
                    Jnz(parts);
                    break;
                default:
                    Debug.Assert(false, "Unrecognized command");
                    break;
            }
        }

        private string GetRegisters()
        {
            return string.Join("\t", Registers.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }

        private void Jnz(string[] parts)
        {
            var x = GetValue(parts[1]);
            var y = GetValue(parts[2]);
            InstructionPtr += (x != 0) ? y : 1;
        }

        private void Mul(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            var y = GetValue(parts[2]);
            SetRegister(parts[1], x * y);
            InstructionPtr++;
        }

        private void Sub(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            var y = GetValue(parts[2]);
            SetRegister(parts[1], x - y);
            InstructionPtr++;
        }

        private void Set(string[] parts)
        {
            var y = GetValue(parts[2]);
            SetRegister(parts[1], y);
            InstructionPtr++;
        }

        public void SetRegister(string register, long value)
        {
            Registers[register] = value;
        }

        public long GetRegisterValue(string register)
        {
            return Registers.ContainsKey(register) ? Registers[register] : 0;
        }

        protected long GetValue(string registerOrValue)
        {
            return long.TryParse(registerOrValue, out var result) ? result : GetRegisterValue(registerOrValue);
        }
    }
}
