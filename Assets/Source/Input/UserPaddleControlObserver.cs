using System;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class UserPaddleControlObserver : MonoBehaviour, IObserver<bool>
    {
        [Inject] private readonly IInputMovableReadonlyObservable m_inputMovableObservable = default;

        [SerializeField] Material m_paddleMaterials = default;

        private IDisposable m_disposable = default;

        private void Awake()
        {
            m_disposable = m_inputMovableObservable.Subscribe(this);
        }

        void IObserver<bool>.OnCompleted()
        {
            m_disposable?.Dispose();
        }

        void IObserver<bool>.OnError(Exception error)
        {
            Debug.LogException(error);
        }

        void IObserver<bool>.OnNext(bool value)
        {
            m_paddleMaterials.color = value ? Color.green : Color.red;
        }

        private void OnDestroy()
        {
            m_disposable?.Dispose();
        }
    }
}
