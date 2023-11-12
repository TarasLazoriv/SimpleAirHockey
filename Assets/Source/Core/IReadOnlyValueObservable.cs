using System;

namespace SimpleAirHockey.Runtime
{
    public interface IReadOnlyValueObservable<out T> : IReadOnlyValue<T>, IObservable<T>
    {
    }
}