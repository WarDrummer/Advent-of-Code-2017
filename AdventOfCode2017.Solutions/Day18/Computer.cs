using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day18
{
    internal class Computer
    {
        protected readonly string[][] Instructions;
        protected readonly Dictionary<string, long> Registers = new Dictionary<string, long>();
        protected long InstructionPtr;
        protected long LastPlayed;
        public long LastRecovered { get; private set; }
        public bool StackOverflow => InstructionPtr >= Instructions.Length || InstructionPtr < 0;


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
                case "snd":
                    Snd(parts);
                    break;
                case "set":
                    Set(parts);
                    break;
                case "add":
                    Add(parts);
                    break;
                case "mul":
                    Mul(parts);
                    break;
                case "mod":
                    Mod(parts);
                    break;
                case "rcv":
                    Rcv(parts);
                    break;
                case "jgz":
                    Jgz(parts);
                    break;
                default:
                    Debug.Assert(false, "Unrecognized command");
                    break;
            }
        }

        private void Jgz(string[] parts)
        {
            var x = GetValue(parts[1]);
            var y = GetValue(parts[2]);
            InstructionPtr += (x > 0) ? y : 1;
        }

        private void Mod(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            var y = GetValue(parts[2]);
            SetRegister(parts[1], x % y);
            InstructionPtr++;
        }

        private void Mul(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            var y = GetValue(parts[2]);
            SetRegister(parts[1], x * y);
            InstructionPtr++;
        }

        private void Add(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            var y = GetValue(parts[2]);
            SetRegister(parts[1], x + y);
            InstructionPtr++;
        }

        private void Set(string[] parts)
        {
            var y = GetValue(parts[2]);
            SetRegister(parts[1], y);
            InstructionPtr++;
        }

        protected virtual void Snd(string[] parts)
        {
            LastPlayed = GetValue(parts[1]);
            InstructionPtr++;
        }

        protected virtual void Rcv(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            if (x != 0)
            {
                LastRecovered = LastPlayed;
                Terminate = true;
            }
            InstructionPtr++;
        }

        public void SetRegister(string register, long value)
        {
            Registers[register] = value;
        }

        protected long GetRegisterValue(string register)
        {
            return Registers.ContainsKey(register) ? Registers[register] : 0;
        }

        protected long GetValue(string registerOrValue)
        {
            return long.TryParse(registerOrValue, out var result) ? result : GetRegisterValue(registerOrValue);
        }
    }
}