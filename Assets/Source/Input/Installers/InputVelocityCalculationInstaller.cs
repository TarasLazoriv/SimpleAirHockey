using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class InputVelocityCalculationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container
                .Bind<IInputVelocityCalculationCommand>()
                .To<InputVelocityCalculation>()
                .AsSingle();
        }
    }
}