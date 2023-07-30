using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PushableObjectController : MonoBehaviour
    {
        private Transform _transform;
        private Transform _player;
        private Vector2 _offset;

        private float _distance;
        private bool _canMove = false;

        private float FollowSpeed => DataManager.Instance.GameData.GetMoveSpeed() * 0.8f;


        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            if (!_player) return;

            if (!_canMove) return;

            Vector2 playerPosition = new Vector2(_player.transform.position.x, _transform.position.y);
            Vector2 targetPose = playerPosition + _offset;

            _transform.position = Vector2.Lerp(_transform.position, targetPose, FollowSpeed * Time.deltaTime);
            float deltaDistance = Vector2.Distance(playerPosition, _transform.position);
            float yDeltaDistance = Mathf.Abs(playerPosition.y - _transform.position.y) + 0.5f;

            if (!(deltaDistance > _distance) &&
                !(deltaDistance < _transform.localScale.x - .7f) &&
                !(yDeltaDistance <= 0.25f)) return;

            SetPlayer(null, 0);
        }

        public void SetPlayer(Transform player, float distance)
        {
            if (player == null)
            {
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