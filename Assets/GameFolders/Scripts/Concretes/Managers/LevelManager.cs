using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public void LoadLevel(int Level)
        {
            SceneManager.LoadScene(Level);
        }
    }
}
