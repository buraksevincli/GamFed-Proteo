using System;
using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PushableObjectController : MonoBehaviour
    {
        [SerializeField] private float targetDistance;

        private Transform _player;
        private Vector2 _offset;

        private float _distance;
        private bool _canMove = false;
        
        private float FollowSpeed => DataManager.Instance.GameData.GetMoveSpeed() * 0.8f;

        private void FixedUpdate()
        {
            if (!_player) return;

            if (!_canMove) return;

            Vector2 playerPosition = new Vector2(_player.transform.position.x, transform.position.y);
            Vector2 targetPose = playerPosition + _offset;
            
            transform.position = Vector2.Lerp(transform.position, targetPose, FollowSpeed * Time.deltaTime);
            float deltaDistance = Vector2.Distance(playerPosition, transform.position);
            float yDeltaDistance = Mathf.Abs(playerPosition.y - transform.position.y) + 0.5f;
            
            if (!(deltaDistance > _distance) && 
                !(deltaDistance < transform.localScale.x + 0.2f) && 
                !(yDeltaDistance <= 0.25f)) return;
            
            SetPlayer(null, 0);
        }

        public void SetPlayer(Transform player, float distance)
        {
            if (player == null)
            {
                //offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
                _offset = Vector2.zero;
                _distance = 0;
                _player = null;
                _canMove = !_canMove;
                PullAndPush.Instance.BreakLineRenderer();
                return;
            }
            
            if (!_player)
            {
                _player = player;
                _distance = distance;
                
                _offset = transform.position - player.position;
                _offset.y = 0;

                // if (_player.position.x > transform.position.x)
                // {
                //     offset *= -1;
                // }
                
                _canMove = !_canMove;
                
                return;
            }
            
            _offset = Vector2.zero;
            _distance = 0;
            _player = null;
            _canMove = !_canMove;
            PullAndPush.Instance.BreakLineRenderer();
        }
    }
}