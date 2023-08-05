using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class LineRendererController : MonoSingleton<LineRendererController>
    {
        private LineRenderer _lineRenderer;
        private Transform _playerPose;
        private Transform _targetPose;

        protected override void Awake()
        {
            base.Awake();
            _lineRenderer = GetComponent<LineRenderer>();
        }
        
        private void Update()
        {
            if (!_playerPose && !_targetPose) return;

            _lineRenderer.SetPosition(0, _playerPose.position);
            _lineRenderer.SetPosition(1, _targetPose.position);
        }

        public void OnSetLineRendererPosition(Transform playerPose, Transform targetPose)
        {
            _playerPose = null;
            _targetPose = null;
            
            _playerPose = playerPose;
            _targetPose = targetPose;
        }

        public void BreakTheLineRenderer()
        {
            _playerPose = null;
            _targetPose = null;
            
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}