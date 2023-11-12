namespace SimpleAirHockey.Runtime
{
    public interface IReadOnlyValue<out T>
    {
        public T Value { get; }
    }
}