namespace SimpleAirHockey.Runtime
{
    public abstract class ReadOnlyValue<T> : IReadOnlyValue<T>
    {
        public T Value { get; }
        protected ReadOnlyValue(T value = default)
        {
            Value = value;
        }

    }
}