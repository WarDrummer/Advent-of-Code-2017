using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017.Solutions.Day18
{
    internal class ComputerV2 : Computer
    {
        public int Id { get; }
        public ComputerV2 PairedComputer { get; set; }
        public long SendCount { get; set; }

        public bool Waiting => _received.Count < 1 && IsReceiving;
       
        private bool IsReceiving => Instructions[InstructionPtr][0] == "rcv";

        private readonly Queue<long> _received = new Queue<long>();

        public override bool Terminate
        {
            get => Waiting || StackOverflow;
            set => throw new Exception("Liskov Violation!");
        }

        public ComputerV2(IEnumerable<string> instructions, int id) : base(instructions)
        {
            Id = id;
        }

        protected override void Rcv(string[] parts)
        {
            if (_received.Count > 0)
            {
                var value = _received.Dequeue();
                SetRegister(parts[1], value);
                InstructionPtr++;
            }
            else
            {
                //Console.WriteLine("Waiting...");
            }
        }

        protected override void Snd(string[] parts)
        {
            SendCount++;
            PairedComputer.QueueValue(GetValue(parts[1]));
            InstructionPtr++;
            
            //if (Id == 1 && SendCount > 10000)
            //{
            //    throw new Exception("Swing and a miss...");
            //}
        }

        public void QueueValue(long value)
        {
            _received.Enqueue(value);
        }

        public string GetInstruction()
        {
            var sb = new StringBuilder();
            sb.Append($"Program({Id}) - ")
                .Append($"{string.Join(" ", Instructions[InstructionPtr])}")
                .Append('\t')
                .Append($"IP: {InstructionPtr} ");

            return sb.ToString();
        }

        public string GetState()
        {
            var sb = new StringBuilder();

            foreach (var r in Registers)
                sb.Append('\t').Append($"{r.Key}: {r.Value}");

            sb.Append('\t').Append($"IP: {InstructionPtr}");

            sb.AppendLine()
                .Append('\t')
                .Append($"Queued: {string.Join(", ", _received.ToArray())}")
                .AppendLine();

            sb.Append('\t')
                .Append($"Send Count: {SendCount}")
                .AppendLine();

            return sb.ToString();
        }
    }
}