using System;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class PullAndPush : MonoSingleton<PullAndPush>
    {
        [SerializeField] private Transform mouthTransform;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float distance;
        [SerializeField] private float ropeTolerance;

        private PushableObjectController _pushableObjectController;
        private Vector2 _direction = Vector2.right;
        private bool _isConnected = false;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnCheckConnection += OnCheckConnectionHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnCheckConnection -= OnCheckConnectionHandler;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal != 0)
            {
                _direction = new Vector2( horizontal > 0 ? 1 : -1, 0);
            }
        }

        private void OnCheckConnectionHandler()
        {
            if (_isConnected)
            {
                // break connection
                _pushableObjectController.SetPlayer(null, 0);
                return;
            }
            
            RaycastHit2D hit = Physics2D.Raycast(mouthTransform.position, _direction , distance, targetLayer);

            if (hit.collider == null) return;
            
            _isConnected = true;

            Collider2D obj = hit.collider;

            _pushableObjectController = obj.GetComponent<PushableObjectController>();
                
            LineRendererController.Instance.OnSetLineRendererPosition(mouthTransform , _pushableObjectController.transform);
            _pushableObjectController.SetPlayer(transform, distance + ropeTolerance);
        }

        public void BreakLineRenderer()
        {
            LineRendererController.Instance.BreakTheLineRenderer();
            _isConnected = false;
            _pushableObjectController = null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Debug.DrawRay(mouthTransform.position, _direction * distance, Color.blue);
        }
#endif
    }
}
