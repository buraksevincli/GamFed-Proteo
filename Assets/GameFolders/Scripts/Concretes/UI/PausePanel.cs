using UnityEngine;

namespace GameFolders.Scripts.Concretes.UI
{
    public class PausePanel : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}
