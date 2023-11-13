using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class GoalCommandInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container
                .Bind<IGoalCommand>()
                .To<GoalCommand>()
                .AsSingle();
            
        }
    }
}