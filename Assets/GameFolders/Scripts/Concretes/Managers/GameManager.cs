using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private int _activeSceneIndex;
        
        public void NextScene()
        {
            _activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (_activeSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                _activeSceneIndex = 0;
            }
            else
            {
                _activeSceneIndex += 1;
            }

            SceneManager.LoadScene(_activeSceneIndex);
        }
    }
}