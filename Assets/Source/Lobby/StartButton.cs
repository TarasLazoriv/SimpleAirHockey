using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleAirHockey.Runtime
{
    public sealed class StartButton : MonoBehaviour
    {
        public async void Load()
        {
            await SceneManager.LoadSceneAsync("GameRoundControllerScene", LoadSceneMode.Additive);

            await SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}