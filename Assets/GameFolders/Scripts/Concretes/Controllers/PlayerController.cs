using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Interactives;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private List<GameObject> _interactedObject = new List<GameObject>();

        private IPlayerInput _input;
        private IMover _mover;
        private IJump _jump;
        private IFlip _flip;
        private IAnimator _animator;

        private OnGround _onGround;
        private PlayerData _playerData;

        private float _horizontal;
        private bool _jumpButtonDown;
        
        private void Awake()
        {
            _playerData = Resources.Load("Data/PlayerData") as PlayerData;
            _onGround = GetComponent<OnGround>();
            
            _input = new PcInput();
            _mover = new Mover(this);
            _jump = new Jump(this);
            _flip = new Flip(this);
            _animator = new PlayerAnimatorController(this);
        }

        private void FixedUpdate()
        {
            _flip.FixedTick(_horizontal);
            _mover.FixedTick(_horizontal,_playerData.MoveSpeed);

            if (_jumpButtonDown)
            {
                _jump.FixedTick(_playerData.JumpForce);
                _jumpButtonDown = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out InteractiveObjectsController interactiveObject))
            {
                _interactedObject.Add(col.gameObject);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.activeSelf) return;
            
            if (other.TryGetComponent(out InteractiveObjectsController interactiveObject))
            {
                _interactedObject.Remove(other.gameObject);
            }

            if (other.TryGetComponent(out IInteractive interactive))
            {
                interactive.Interactive();
            }
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;
            
            _animator.SetRunAnimation(_horizontal);
            _animator.SetJumpAnimationValue(_mover.GetVelocityY());

            if (_input.JumpButtonDown && _onGround.IsOnGround)
            {
                _animator.SetJumpAnimation();
                _jumpButtonDown = true;
            }
        }

        public void InteractiveButtonController()
        {
            if (_interactedObject != null)
            {
                foreach (GameObject interactedObject in _interactedObject)
                {
                    interactedObject.SetActive(false);
                }
            }
        }
    }
}

