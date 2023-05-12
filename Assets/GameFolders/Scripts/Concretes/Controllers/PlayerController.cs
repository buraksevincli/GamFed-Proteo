using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Interactives;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private List<GameObject> _excavableObject = new List<GameObject>();
        private List<GameObject> _barkObject = new List<GameObject>();

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
            if (col.TryGetComponent(out ExcavableObject excavableObject))
            {
                _excavableObject.Add(col.gameObject);
            }

            if (col.TryGetComponent(out BarkAndCollectObject barkObject))
            {
                _barkObject.Add(col.gameObject);
            }
            
            if (col.TryGetComponent(out InteractAndCollectObject interactObject))
            {
                interactObject.SetThis();
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out BarkAndCollectObject barkObject))
            {
                if (!other.gameObject.activeSelf) return;
                _barkObject.Remove(other.gameObject);
            }
            
            if (other.TryGetComponent(out ExcavableObject excavableObject))
            {
                if (!other.gameObject.activeSelf) return;
                _excavableObject.Remove(other.gameObject);
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

        public void ExcavableObjectController()
        {
            if (_excavableObject != null)
            {
                foreach (GameObject excavableObject in _excavableObject)
                {
                    excavableObject.SetActive(false);
                }
            }
        }

        public void BarkObjectController()
        {
            if (_barkObject != null)
            {
                foreach (GameObject barkObject in _barkObject)
                {
                    barkObject.SetActive(false);
                }
            }
        }
    }
}

