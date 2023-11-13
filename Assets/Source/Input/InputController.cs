using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class InputController : MonoBehaviour
    {
        [Inject] private readonly IInputVelocityCalculationCommand m_inputVelocityCalculation = default;
        [Inject] private readonly IInputMovableReadonly m_inputMovable = default;

        [SerializeField] private Rigidbody m_userPaddle = default;
        

        private void Update()
        {
            if (m_inputMovable.Value)
            {
                m_userPaddle.velocity = m_inputVelocityCalculation.Execute(m_userPaddle.position);
            }
        }

    }
}
