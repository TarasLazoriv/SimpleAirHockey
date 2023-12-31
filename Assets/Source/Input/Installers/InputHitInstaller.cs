using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class InputHitInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container
                .Bind<IInputHit>()
                .To<InputHitPositionState>()
                .AsSingle();

            Container
                .Bind<IInputHitReadonly>()
                .To<IInputHit>()
                .FromResolve()
                .AsSingle();


            Container
                .Bind<IInputMovable>()
                .To<InputHitMovableState>()
                .AsSingle();

            Container
                .Bind<IInputMovableReadonlyObservable>()
                .To<IInputMovable>()
                .FromResolve()
                .AsSingle();

            Container
                .Bind<IInputMovableReadonly>()
                .To<IInputMovableReadonlyObservable>()
                .FromResolve()
                .AsSingle();

        }


        // ReSharper disable  ClassNeverInstantiated.Local
        private sealed class InputHitPositionState : Value<Vector3>, IInputHit { }
        private sealed class InputHitMovableState : ValueObservable<bool>, IInputMovable { }
    }
}