using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2017.Solutions.Day18
{
    internal class Computer
    {
        protected readonly string[][] Instructions;
        protected readonly Dictionary<string, long> Registers = new Dictionary<string, long>();
        protected long InstructionPointer;
        protected long LastPlayed;
        public long LastRecovered { get; private set; }

        public Computer(IEnumerable<string> instructions)
        {
            Instructions = instructions.Select(i => i.Split(' ').ToArray()).ToArray();
        }

        protected virtual bool Terminate { get; set; }

        public void Run()
        {
            while (InstructionPointer >= 0 && 
                   InstructionPointer < Instructions.Length
                   && !Terminate)
            {
                ExecuteCycle();
            }
        }

        public virtual void ExecuteCycle()
        {
            var parts = Instructions[InstructionPointer];
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
            var x = GetRegisterValue(parts[1]);
            if (x > 0)
            {
                var y = GetValue(parts[2]);
                InstructionPointer += y;
            }
            else InstructionPointer++;
        }

        private void Mod(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            SetRegister(parts[1], x % GetValue(parts[2]));
            InstructionPointer++;
        }

        private void Mul(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            SetRegister(parts[1], x * GetValue(parts[2]));
            InstructionPointer++;
        }

        private void Add(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            SetRegister(parts[1], x + GetValue(parts[2]));
            InstructionPointer++;
        }

        private void Set(string[] parts)
        {
            SetRegister(parts[1], GetValue(parts[2]));
            InstructionPointer++;
        }

        protected virtual void Snd(string[] parts)
        {
            LastPlayed = GetValue(parts[1]);
            InstructionPointer++;
        }

        protected virtual void Rcv(string[] parts)
        {
            var x = GetRegisterValue(parts[1]);
            if (x != 0)
            {
                LastRecovered = LastPlayed;
                Terminate = true;
            }
            InstructionPointer++;
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