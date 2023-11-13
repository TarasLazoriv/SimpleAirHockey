namespace SimpleAirHockey.Runtime
{
    public interface IValueObservable<T> : IValue<T>, IReadOnlyValueObservable<T>
    {
    }
}