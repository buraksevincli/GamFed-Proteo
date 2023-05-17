using System;
using GameFolders.Scripts.Abstracts.Interacts;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class InteractObjectController : MonoBehaviour
    {
        [SerializeField] private InteractObject interactObject;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                interactObject.InteractObjectTrigger();
            }
        }
    }
}
