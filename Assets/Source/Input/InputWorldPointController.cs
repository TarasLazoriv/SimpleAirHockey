using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    /// <summary>
    /// It can be easily replaced, for example, with Camera.ScreenToViewportPoint (but it ignore perspective).
    /// </summary>
    public sealed class InputWorldPointController : MonoBehaviour
    {
        [Inject] private readonly IInputHit m_inputHit = default;
        [Inject] private readonly IInputMovable m_inputMovable = default;

        [SerializeField] private Camera m_mainCamera = default;

        /// <summary>
        /// Physic operations inside FixedUpdate
        /// </summary>
        private void FixedUpdate()
        {
            // Get the current mouse coordinates in world coordinates
            Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

            // Create a layer mask, including only the "Input" layer
            int layerMask = 1 << LayerMask.NameToLayer("Input");

            // Check if the ray hits the "Input" layer
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                m_inputHit.Value = hit.point;
                m_inputMovable.Value = true;
            }
            else
            {
                m_inputMovable.Value = false;
            }
        }

    }
}