using UnityEngine;

namespace SimpleAirHockey.Runtime
{
    public interface IInputVelocityCalculationCommand
    {
        public Vector3 Execute(Vector3 paddlePosition);
    }
}