using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Solutions.Day25
{
    public class Machine
    {
        private Node<bool> _node = new Node<bool>();

        public bool Value
        {
            get => _node.Value;
            set => _node.Value = value;
        }

        public Machine(State state)
        {
            State = state;
        }

        public State State { get; set; }

        public int Checksum => TraverseNodes().Count(node => node.Value);

        public void Step()
        {
            State.Update(this);
        }

        public IEnumerable<Node<bool>> TraverseNodes()
        {
            var node = _node;
            while (node.Left != null)
                node = node.Left;

            do
            {
                yield return node;
                node = node.Right;
            } while (node != null);
        }

        public void MoveLeft()
        {
            if (_node.Left == null)
                _node.Left = new Node<bool> { Right = _node };
            _node = _node.Left;
        }

        public void MoveRight()
        {
            if (_node.Right == null)
                _node.Right = new Node<bool> { Left = _node };
            _node = _node.Right;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var node in TraverseNodes())
            {
                var v = node.Value ? 1 : 0;
                if (node != _node)
                    sb.Append(v).Append('\t');
                else
                    sb.Append('[').Append(v).Append(']').Append('\t');
            }

            sb.Append($" next {State}");
            return sb.ToString();
        }
    }
}