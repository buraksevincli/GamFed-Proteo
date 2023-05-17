using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class PullAndPush : MonoBehaviour
    {
        [SerializeField] private Transform mouthTransform;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float distance;

        private PushableObjectController _pushableObject;
        private Vector2 _direction = Vector2.right;
        private bool _isConnected = false;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnFollowPlayer += SetLineRendererPositions;
        }

        private void Update()
        {
            if(_isConnected) return;

            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal != 0)
            {
                _direction = new Vector2( horizontal > 0 ? 1 : -1, 0);
            }
            
            RaycastHit2D hit = Physics2D.Raycast(mouthTransform.position, _direction , distance, targetLayer);
            
            if (hit)
            {
                //if(_pushableObject) return;
                
                Collider2D obj = hit.collider;

                _pushableObject = obj.GetComponent<PushableObjectController>();
            }
            else
            {
                //if(!_pushableObject) return;
                
                BreakLineRenderer();
                _pushableObject = null;
            }
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnFollowPlayer -= SetLineRendererPositions;
        }

        private void SetLineRendererPositions()
        {
            if(!_pushableObject) return;

            LineRendererController.Instance.OnSetLineRendererPosition(mouthTransform , _pushableObject.transform);
            
            _pushableObject.SetPlayer(transform);
            _isConnected = !_isConnected;
        }

        private void BreakLineRenderer()
        {
            LineRendererController.Instance.BreakTheLineRenderer();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Debug.DrawRay(mouthTransform.position, _direction * distance, Color.blue);
        }
#endif
    }
}
