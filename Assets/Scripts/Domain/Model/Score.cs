using System;

namespace Domain.Model
{
    public class Score : IEquatable<Score>
    {
        public int Value { get; }

        public Score(int value)
        {
            Value = value;
        }

        public Score ChangeScore(Score arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            return new Score(Value + arg.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(Score other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Score) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}