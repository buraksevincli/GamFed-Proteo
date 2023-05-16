using System;
using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PushableObjectController : MonoBehaviour
    {
        [SerializeField] private float followSpeed;
        [SerializeField] private float targetDistance;
        [SerializeField] private Vector2 offset;

        private Transform _player;

        private bool _canMove = false;

        private void Update()
        {
            if (!_player) return;

            if (!_canMove) return;

            Vector2 playerPosition = new Vector2(_player.transform.position.x, transform.position.y);
            Vector2 targetPose = playerPosition + offset;
            transform.position = Vector2.Lerp(transform.position, targetPose, followSpeed * Time.deltaTime);
        }

        public void SetPlayer(Transform player)
        {
            if (!_player)
            {
                _player = player;
                
                if (_player.position.x > transform.position.x)
                {
                    offset *= -1;
                }
                
                _canMove = !_canMove;
                
                return;
            }

            offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));

            _player = null;
            _canMove = !_canMove;
            LineRendererController.Instance.BreakTheLineRenderer();
        }
    }
}