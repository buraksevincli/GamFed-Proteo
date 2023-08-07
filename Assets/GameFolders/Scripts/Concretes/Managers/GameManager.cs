using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public bool levelCompleted;
        
        private int _activeSceneIndex;

        private void Start()
        {
            _activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Application.targetFrameRate = 60;
        }

        public void NextScene()
        {
            if (_activeSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                _activeSceneIndex = 0;
            }
            else
            {
                _activeSceneIndex += 1;
            }
            
            if (_activeSceneIndex -1 >= DataManager.Instance.GameData.highLevel)
            {
                DataManager.Instance.GameData.highLevel = _activeSceneIndex - 1;
                PlayerPrefs.SetInt("Level", DataManager.Instance.GameData.highLevel);
            }

            SceneManager.LoadScene(_activeSceneIndex);
        }

        public void LoadThisScene()
        {
            SceneManager.LoadScene(_activeSceneIndex);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}