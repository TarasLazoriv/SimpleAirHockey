using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class GameRoundInit : MonoBehaviour
    {
        [Inject] private readonly IRoundUserStart m_userStart = default;

        [SerializeField] private Transform UserPoint = default;
        [SerializeField] private Transform EnemyPoint = default;
        [SerializeField] private Transform Puck = default;


        private void Awake()
        {
            Puck.position = m_userStart.Value ? UserPoint.position : EnemyPoint.position;
        }

    }
}