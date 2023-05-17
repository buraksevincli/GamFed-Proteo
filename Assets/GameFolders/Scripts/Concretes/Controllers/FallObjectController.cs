using System;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FallObjectController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                DataManager.Instance.EventData.OnFallObjectTriggered?.Invoke();
            }
        }
    }
}
