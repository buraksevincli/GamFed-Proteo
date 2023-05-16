using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] private Transform[] transforms;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;

        private bool _isOnGround;
        public bool IsOnGround => _isOnGround;

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
                _isOnGround = true;
            }
            else
            {
                _isOnGround = false;
            }
        }
    }
}
