using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class ScoreObserver : MonoBehaviour, IObserver<ValueTuple<uint, uint>>
    {
        [Inject] private readonly IRoundScoreReadonlyObservable m_roundScoreObservable = default;

        [SerializeField] TextMeshProUGUI m_textMeshPro = default;

        private IDisposable m_disposable = default;

        private void Awake()
        {
            m_disposable = m_roundScoreObservable.Subscribe(this);
        }

        void IObserver<ValueTuple<uint, uint>>.OnCompleted()
        {
            m_disposable?.Dispose();
        }

        void IObserver<ValueTuple<uint, uint>>.OnError(Exception error)
        {
            Debug.LogException(error);
        }

        void IObserver<ValueTuple<uint, uint>>.OnNext(ValueTuple<uint, uint> value)
        {
            m_textMeshPro.text = $"{value.Item1}:{value.Item2}";
        }

        private void OnDestroy()
        {
            m_disposable?.Dispose();
        }
    }
}
