using System;
using System.Collections.Generic;

namespace SimpleAirHockey.Runtime
{
    public abstract class ValueObservable<T> : IValueObservable<T>
    {
        private readonly List<IObserver<T>> m_observers = new List<IObserver<T>>();

        private T m_value = default;

        T IReadOnlyValue<T>.Value => m_value;

        T IValue<T>.Value
        {
            get => m_value;
            set
            {
                bool changed = !m_value.Equals(value);
                m_value = value;
                if (changed)
                {
                    NotifyObservers();
                }
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!m_observers.Contains(observer))
            {
                m_observers.Add(observer);
            }

            // Return IDisposable for unsubscribing
            return new Unsubscriber(m_observers, observer);
        }

        // Method that notifies observers of a change
        private void NotifyObservers()
        {
            foreach (IObserver<T> observer in m_observers)
            {
                observer.OnNext(m_value);
            }
        }

        private sealed class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<T>> m_observers = default;
            private readonly IObserver<T> m_observer = default;

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                m_observers = observers;
                m_observer = observer;
            }

            public void Dispose()
            {
                if (m_observers.Contains(m_observer))
                {
                    m_observers.Remove(m_observer);
                }
            }
        }
    }
}