using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class GoalCommand : IGoalCommand
    {
        [Inject] private readonly IRoundScoreObservable m_roundScoreObservable = default;
        [Inject] private readonly ZenjectSceneLoader m_zenjectSceneLoader = default;
        public async Task Execute(bool userGate)
        {
            //round result sequence

            ValueTuple<uint, uint> val = userGate
                ? (m_roundScoreObservable.Value.Item1, m_roundScoreObservable.Value.Item2 + 1)
                : (m_roundScoreObservable.Value.Item1 + 1, m_roundScoreObservable.Value.Item2);
            m_roundScoreObservable.Value = val;

            await Task.Delay(TimeSpan.FromSeconds(2));

            await m_zenjectSceneLoader.LoadSceneAsync("RoundResultScene", LoadSceneMode.Additive, container =>
            {
                container
                    .Bind<IRoundResultReadonly>()
                    .To<RoundResultState>()
                    .FromInstance(new RoundResultState(!userGate))
                    .AsSingle();
            } );

            await SceneManager.UnloadSceneAsync("GameRoundScene");

            await Task.Delay(TimeSpan.FromSeconds(5));

            SceneManager.LoadSceneAsync("GameRoundScene",LoadSceneMode.Additive);

            await SceneManager.UnloadSceneAsync("RoundResultScene");

        }

        private sealed class RoundResultState : Value<bool>, IRoundResultReadonly
        {
            public RoundResultState(bool result) : base(result) { }
        }
    }

}