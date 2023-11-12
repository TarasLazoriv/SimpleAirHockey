using System.ComponentModel;
using UnityEngine;

namespace SimpleAirHockey.Runtime
{
    [CreateAssetMenu(fileName = "InputParamsObject", menuName = "Custom/InputParamsObject")]
    public sealed class InputParams : ScriptableObject
    {
        [SerializeField] private float m_sensitivity = 5.0f; // Object movement sensitivity
        [SerializeField] private float m_minDistanceToReact = 0.2f; // Distance at which the object stops
        [SerializeField] private float m_distanceSpeedDependency = 1.0f; // Speed dependency on distance (less - faster)
        [SerializeField] private float m_minimumSpeed = 1f; // Minimum speed of the object

        public IInputSensitivity InputSensitivity => m_inputSensitivity;
        public IInputMinDistance InputMinDistance => m_inputMinDistance;
        public IInputDistanceSpeedDependency InputDistanceSpeedDependency => m_inputDistanceSpeedDependency;
        public IInputMinimumSpeed InputMinimumSpeed => m_inputMinimumSpeed;

        #region interface creation

        private readonly InputSensitivityState m_inputSensitivity = default;
        private readonly InputMinDistanceState m_inputMinDistance = default;
        private readonly InputDistanceSpeedDependencyState m_inputDistanceSpeedDependency = default;
        private readonly InputMinimumSpeedState m_inputMinimumSpeed = default;

        public InputParams()
        {
            m_inputSensitivity = new InputSensitivityState(m_sensitivity);
            m_inputMinDistance = new InputMinDistanceState(m_minDistanceToReact);
            m_inputDistanceSpeedDependency = new InputDistanceSpeedDependencyState(m_distanceSpeedDependency);
            m_inputMinimumSpeed = new InputMinimumSpeedState(m_minimumSpeed);

        }


        private sealed class InputSensitivityState : ReadOnlyValue<float>, IInputSensitivity
        {
            public InputSensitivityState(float val) : base(val) { }
        }
        private sealed class InputMinDistanceState : ReadOnlyValue<float>, IInputMinDistance
        {
            public InputMinDistanceState(float val) : base(val) { }
        }
        private sealed class InputDistanceSpeedDependencyState : ReadOnlyValue<float>, IInputDistanceSpeedDependency
        {
            public InputDistanceSpeedDependencyState(float val) : base(val) { }
        }
        private sealed class InputMinimumSpeedState : ReadOnlyValue<float>, IInputMinimumSpeed
        {
            public InputMinimumSpeedState(float val) : base(val) { }
        }

        #endregion
    }
}