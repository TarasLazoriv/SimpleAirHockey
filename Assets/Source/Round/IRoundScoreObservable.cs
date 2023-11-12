using System;

namespace SimpleAirHockey.Runtime
{
    public interface IRoundScoreObservable : IValueObservable<ValueTuple<uint, uint>>, IRoundScoreReadonlyObservable { }


}