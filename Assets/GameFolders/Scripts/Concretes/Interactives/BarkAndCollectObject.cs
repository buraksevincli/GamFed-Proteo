using System;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class BarkAndCollectObject : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        private Rigidbody2D _rigidbody2D;
        private float _maxDistance = 0.5f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckExcavableObjects();
        }

        private void CheckExcavableObjects()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.forward * _maxDistance, layerMask);

            Debug.DrawRay(transform.position, -transform.forward * _maxDistance, Color.red);
            
            if (hit2D.collider != null)
            {
                _rigidbody2D.simulated = false;
            }
            else
            {
                _rigidbody2D.simulated = true;
            }
        }
    }
}

