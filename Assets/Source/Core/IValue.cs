namespace SimpleAirHockey.Runtime
{
    public interface IValue<T> : IReadOnlyValue<T>
    {
        public new T Value { get; set; }
    }
}