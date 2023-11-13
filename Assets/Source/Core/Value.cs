using System.Linq;

namespace SimpleAirHockey.Runtime
{
    public abstract class Value<T> : IValue<T>
    {
        private T m_value = default;
        protected Value(T value = default)
        {
            m_value = value;
        }

        T IReadOnlyValue<T>.Value => m_value;

        T IValue<T>.Value
        {
            get => m_value;
            set => m_value = value;
        }
    }
}