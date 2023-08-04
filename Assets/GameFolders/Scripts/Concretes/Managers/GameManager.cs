using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public void NextScene()
        {
            int activeSceneindex;

            activeSceneindex = SceneManager.GetActiveScene().buildIndex;

            if (activeSceneindex == SceneManager.sceneCountInBuildSettings - 1)
            {
                activeSceneindex = 0;
            }
            else
            {
                activeSceneindex += 1;
            }

            SceneManager.LoadScene(activeSceneindex);
        }
    }
}