using System;
using GameFolders.Scripts.Concretes.Managers;
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

        private void Update()
        {
            DataManager.Instance.EventData.OnFeelCold?.Invoke();
        }

        private void OnChangeEnergyFillAmountHandler(float value)
        {
            image.fillAmount = value;
            image.color = gradient.Evaluate(value);
        }
    }
}