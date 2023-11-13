using TMPro;
using UnityEngine;
using Zenject;

namespace SimpleAirHockey.Runtime
{
    public sealed class RoundResultInit : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_textMeshPro = default;
        [SerializeField] private Animator m_animator = default;

        [Inject] private readonly IRoundResultReadonly m_roundResult = default;

        private const string WinText = "Triumph";
        private const string LooseText = "Failure";

        private void Awake()
        {
            m_textMeshPro.text = m_roundResult.Value ? WinText : LooseText;
            m_animator.SetBool("Win", m_roundResult.Value);
        }
    }
}
