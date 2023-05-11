using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerInput _input;
        private IMover _mover;
        private IJump _jump;
        private IFlip _flip;

        private OnGround _onGround;
        private PlayerData _playerData;

        private float _horizontal;
        private bool _jumpButtonDown;
        private GameObject _interactedObject;
        
        private void Awake()
        {
            _playerData = Resources.Load("Data/PlayerData") as PlayerData;
            _input = new PcInput();
            _mover = new Mover(this);
            _jump = new Jump(this);
            _flip = new Flip(this);
            _onGround = GetComponent<OnGround>();
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
            InteractiveObjectsController interactiveObject = col.GetComponent<InteractiveObjectsController>();
            
            if (interactiveObject != null)
            {
                _interactedObject = col.gameObject;
            }
            
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            InteractiveObjectsController interactiveObject = other.GetComponent<InteractiveObjectsController>();
        
            if (interactiveObject != null)
            {
                _interactedObject = null;
            }
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.JumpButtonDown && _onGround.IsOnGround)
            {
                _jumpButtonDown = true;
            }
        }

        public void InteractiveButtonController()
        {
            if (_interactedObject != null)
            {
                _interactedObject.SetActive(false);
            }
        }
    }
}

