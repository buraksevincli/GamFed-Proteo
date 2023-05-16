using System;
using System.Runtime.Serialization;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class PullAndPush : MonoBehaviour
    {
        [SerializeField] private Transform mouthTransform;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float distance;

        private PushableObjectController _pushableObject;
        private bool _isConnected = false;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnFollowPlayer += SetLineRendererPositions;
        }

        private void Update()
        {
            if(_isConnected) return;
            
            RaycastHit2D hit = Physics2D.Raycast(mouthTransform.position, mouthTransform.right, distance, targetLayer);
            
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
    }
}
