using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleAirHockey.Runtime
{
    public sealed class GameRoundControllerInit : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadSceneAsync("GameRoundScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("GameScoreScene", LoadSceneMode.Additive);
        }

    }
}