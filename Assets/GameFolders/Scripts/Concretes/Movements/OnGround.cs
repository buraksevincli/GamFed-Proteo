using System;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] private Transform[] transforms;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;

        private BoxCollider2D _collider2D;
        
        private bool _isOnGround;
        public bool IsOnGround => _isOnGround;

        private void Awake()
        {
            _collider2D = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            foreach (Transform footTransform in transforms)
            {
                CheckFoots(footTransform);
                
                if(_isOnGround) break;
            }
        }

        private void CheckFoots(Transform footTransform)
        {
            RaycastHit2D hit2D =
                Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
            
            Debug.DrawRay(footTransform.position,footTransform.forward * maxDistance, Color.red);

            if (hit2D.collider != null)
            {
                Vector2 idleColliderSize = new Vector2(1.224049f, 1.183167f);
                _collider2D.size = idleColliderSize;
                _isOnGround = true;
            }
            else
            {
                _isOnGround = false;
                Vector2 jumpColliderSize = new Vector2(1.224049f, 0.6f);
                _collider2D.size = jumpColliderSize;
            }
        }
    }
}
