using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class CampFireController : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                DataManager.Instance.EventData.OnFeelWarm?.Invoke();
            }
        }
    }
}
