using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.UI
{
    public class LevelsPanelController : MonoBehaviour
    {
        [SerializeField] private Button[] levelButtons;

        private void OnEnable()
        {
            int currentLevel = PlayerPrefs.GetInt("Level");

            for (int i = 0; i <= currentLevel; i++)
            {
                levelButtons[i].interactable = true;
            }
        }
    }
}
