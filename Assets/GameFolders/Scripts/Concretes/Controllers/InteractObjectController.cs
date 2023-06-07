using System;
using GameFolders.Scripts.Abstracts.Interacts;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class InteractObjectController : MonoBehaviour
    {
        [SerializeField] private InteractObject interactObject;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (interactObject.gameObject.activeSelf)
            {
                if (col.TryGetComponent(out PlayerController playerController))
                {
                    interactObject.InteractObjectTrigger();
                    _rigidbody2D.simulated = false;
                }
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}