using System;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class GoalTracker : MonoBehaviour
    {
        [SerializeField] private bool m_userGate = default;

        [Inject] private readonly IGoalCommand m_goalCommand = default;

        private void OnTriggerEnter(Collider other)
        {
            m_goalCommand.Execute(m_userGate);
        }
    }

}