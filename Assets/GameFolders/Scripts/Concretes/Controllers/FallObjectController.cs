using System;
using GameFolders.Scripts.Abstracts.Interacts;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FallObjectController : MonoBehaviour
    {
        [SerializeField] private FallObject fallObject;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                fallObject.FallObjectTrigger();
            }
        }
    }
}
