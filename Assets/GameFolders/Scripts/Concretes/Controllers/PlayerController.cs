using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private PlayerData _playerData;

        private float _horizontal;
        private bool _jumpButtonDown;
        
        private void Awake()
        {
            _playerData = Resources.Load("Data/PlayerData") as PlayerData;
            _input = new PcInput();
            _mover = new Mover(this);
            _jump = new Jump(this);
        }

        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal,_playerData.MoveSpeed);

            if (_jumpButtonDown)
            {
                _jump.FixedTick(_playerData.JumpForce);
                _jumpButtonDown = false;
            }
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.JumpButtonDown)
            {
                _jumpButtonDown = true;
            }
        }
    }
}

