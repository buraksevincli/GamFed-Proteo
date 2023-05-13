using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private EnergyController energyController;
        
        private readonly List<GameObject> _excavableObject = new List<GameObject>();
        private readonly List<GameObject> _barkObject = new List<GameObject>();

        private IPlayerInput _input;
        private IMover _mover;
        private IJump _jump;
        private IFlip _flip;
        private IAnimator _animator;

        private static GameData GameData => DataManager.Instance.GameData;

        private OnGround _onGround;
        private WaitForSeconds _waitForcedRestTime;

        private float _horizontal;
        private bool _jumpButtonDown;
        private bool _canMove = true;

        private void Awake()
        {
            _onGround = GetComponent<OnGround>();

            _input = new PcInput();
            _mover = new Mover(this);
            _jump = new Jump(this);
            _flip = new Flip(this);
            _animator = new PlayerAnimatorController(this);

            _waitForcedRestTime = new WaitForSeconds(GameData.ForcedRestTime);
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnEnergyOver += OnEnergyOverHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnEnergyOver -= OnEnergyOverHandler;
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;

            _flip.FixedTick(_horizontal);
            _mover.FixedTick(_horizontal, GameData.MoveSpeed);

            DataManager.Instance.EventData.OnSpendEnergy?.Invoke(Mathf.Abs(_horizontal) * GameData.EnergyDecreaseCoefficient * Time.deltaTime);

            if (_jumpButtonDown)
            {
                if (energyController.Energy < GameData.JumpEnergyDecreaseAmount) return;

                DataManager.Instance.EventData.OnSpendEnergy?.Invoke(GameData.JumpEnergyDecreaseAmount);
                _jump.FixedTick(GameData.JumpForce);
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
            if (other.TryGetComponent(out ExcavableObject excavableObject))
            {
                if (!other.gameObject.activeSelf) return;
                _excavableObject.Remove(other.gameObject);
            }
            
            if (other.TryGetComponent(out BarkAndCollectObject barkObject))
            {
                if (!other.gameObject.activeSelf) return;
                _barkObject.Remove(other.gameObject);
            }
        }

        private void Update()
        {
            if (!_canMove)
            {
                DataManager.Instance.EventData.OnGainEnergy?.Invoke(GameData.EnergyIncreaseCoefficient * Time.deltaTime);
                _horizontal = 0;
                return;
            }
            
            _horizontal = _input.Horizontal;

            if (_horizontal == 0)
            {
                DataManager.Instance.EventData.OnGainEnergy?.Invoke(GameData.EnergyIncreaseCoefficient * Time.deltaTime);
            }

            _animator.SetRunAnimation(_horizontal);
            _animator.SetJumpAnimationValue(_mover.GetVelocityY());

            if (energyController.Energy < GameData.JumpEnergyDecreaseAmount) return;
            
            if (_input.JumpButtonDown && _onGround.IsOnGround)
            {
                _animator.SetJumpAnimation();
                _jumpButtonDown = true;
            }
        }

        private void OnEnergyOverHandler()
        {
            StartCoroutine(ForcedRestCoroutine());
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

        private IEnumerator ForcedRestCoroutine()
        {
            _canMove = false;

            _animator.SetRestAnimation();
            _animator.SetRunAnimation(0); // Temp
            _mover.FixedTick(0, 0);

            yield return _waitForcedRestTime;

            _canMove = true;
        }
    }
}