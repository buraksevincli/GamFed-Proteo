using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Managers;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnergyBarController : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Gradient gradient;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeEnergyFillAmount += OnChangeEnergyFillAmountHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeEnergyFillAmount -= OnChangeEnergyFillAmountHandler;
        }

        private void OnChangeEnergyFillAmountHandler(float value)
        {
            image.fillAmount = value;
            image.color = gradient.Evaluate(value);
        }
    }
}

