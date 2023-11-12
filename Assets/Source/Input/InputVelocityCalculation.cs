using System;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class InputVelocityCalculation : IInputVelocityCalculationCommand
    {
        //Params
        [Inject] private readonly IInputSensitivity m_inputSensitivity = default;
        [Inject] private readonly IInputMinDistance m_inputMinDistance = default;
        [Inject] private readonly IInputDistanceSpeedDependency m_inputDistanceSpeedDependency = default;
        [Inject] private readonly IInputMinimumSpeed m_inputMinimumSpeed = default;

        //RaycastHit
        [Inject] private readonly IInputHitReadonly m_inputHit = default;





        public Vector3 Execute(Vector3 paddlePosition)
        {

            float distance = Vector3.Distance(paddlePosition, new Vector3(m_inputHit.Value.x, paddlePosition.y, m_inputHit.Value.z));

            // If the distance is less than the threshold, stop the movement
            if (distance < m_inputMinDistance.Value)
            {
                return Vector3.zero;
            }
            else
            {
                // Calculate the direction of movement to the mouse pointer
                Vector3 direction = (m_inputHit.Value - paddlePosition).normalized;

                // Calculate the speed coefficient depending on the distance
                float speedFactor = distance / m_inputDistanceSpeedDependency.Value;

                // Speed cannot be lower than m_inputMinimumSpeed
                speedFactor = Math.Max(m_inputMinimumSpeed.Value, speedFactor);

                Debug.LogError(m_inputSensitivity.Value * speedFactor);
                // Set the Rigidbody speed according to the sensitivity and distance dependency
                Vector3 velocity = direction * m_inputSensitivity.Value * speedFactor;

                return new Vector3(velocity.x, default, velocity.z);
            }
        }
    }
}