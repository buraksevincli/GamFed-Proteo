using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class WindController : MonoBehaviour
    {
        [SerializeField] private WindType windType;

        private Transform player;
        private float windDirection;

        private void Start()
        {
            switch (windType)
            {
                case WindType.LeftToRight:
                    windDirection = 1f;
                    break;
                case WindType.RightToLeft:
                    windDirection = -1f;
                    break;
            }
            
            DataManager.Instance.GameData.ResetWindSpeed();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                player = other.transform;
                
                if (player.localScale.x == windDirection)
                {
                    DataManager.Instance.GameData.WindSpeedUp();
                }
                else
                {
                    DataManager.Instance.GameData.WindSlowdown();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            DataManager.Instance.GameData.ResetWindSpeed();
        }
    }

    public enum WindType
    {
        LeftToRight,
        RightToLeft
    }
}


