using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnergyBarController : MonoBehaviour
    {
        private Image _image;
        private PlayerData _playerData;
        
        private IPlayerInput _input;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
            _input = new PcInput();
            _playerData = Resources.Load("Data/PlayerData") as PlayerData;
        }

        private void Update()
        {
            if (_input.Horizontal != 0)
            {
                EnergyDecrease();
            }
            else
            {
                EnergyIncrease();
            }
        }

        private void EnergyDecrease()
        {
            _image.fillAmount -= _playerData.EnergyDecrease * Mathf.Abs(_input.Horizontal) * Time.deltaTime;
        }

        private void EnergyIncrease()
        {
            _image.fillAmount += _playerData.EnergyIncrease * Time.deltaTime;
        }
    }
}

