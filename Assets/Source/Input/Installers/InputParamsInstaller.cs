using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class InputParamsInstaller : MonoInstaller
    {
        [SerializeField] private InputParams m_inputParamsObject = default;

        public override void InstallBindings()
        {

            Container
                .Bind<IInputSensitivity>()
                .FromInstance(m_inputParamsObject.InputSensitivity)
                .AsSingle();

            Container
                .Bind<IInputMinDistance>()
                .FromInstance(m_inputParamsObject.InputMinDistance)
                .AsSingle();

            Container
                .Bind<IInputDistanceSpeedDependency>()
                .FromInstance(m_inputParamsObject.InputDistanceSpeedDependency)
                .AsSingle();

            Container
                .Bind<IInputMinimumSpeed>()
                .FromInstance(m_inputParamsObject.InputMinimumSpeed)
                .AsSingle();
        }
    }
}