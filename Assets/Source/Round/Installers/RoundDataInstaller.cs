using System;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class RoundDataInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container
                .Bind<IRoundScoreObservable>()
                .To<RoundScoreObservableState>()
                .AsSingle();

            Container
                .Bind<IRoundScoreReadonlyObservable>()
                .To<IRoundScoreObservable>()
                .FromResolve()
                .AsSingle();


            Container
                .Bind<IRoundUserStart>()
                .To<RoundUserStartState>()
                .AsSingle();

            Container
                .Bind<IRoundUserStartReadonly>()
                .To<IRoundUserStart>()
                .FromResolve()
                .AsSingle();

        }


        
        // ReSharper disable  ClassNeverInstantiated.Local
        private sealed class RoundScoreObservableState : ValueObservable<ValueTuple<uint, uint>>, IRoundScoreObservable { }

        private sealed class RoundUserStartState : Value<bool>, IRoundUserStart
        {
            public RoundUserStartState() : base(true)
            {
                
            }
        }
    }
}