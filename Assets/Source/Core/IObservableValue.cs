using System;
using System.Collections.Generic;

namespace SimpleAirHockey.Runtime
{
    public abstract class ValueObservable<T> : CustomObservable<T>, IValueObservable<T>
    {
        private T m_value = default;

        protected ValueObservable(T value = default)
        {
            m_value = value;
        }
        
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
                    NotifyObservers(m_value);
                }
            }
        }

    }
}