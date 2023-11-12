using System;

namespace SimpleAirHockey.Runtime
{
    public interface IRoundScoreReadonlyObservable : IReadOnlyValueObservable<ValueTuple<uint, uint>> { }
}