using System;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class ColdBarController : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Gradient gradient;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeColdFillAmount += OnChangeColdFillAmountHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeColdFillAmount -= OnChangeColdFillAmountHandler;
        }

        private void Update()
        {
            DataManager.Instance.EventData.OnFeelCold?.Invoke();
        }

        private void OnChangeColdFillAmountHandler(float value)
        {
            image.fillAmount = value;
            image.color = gradient.Evaluate(value);
        }
    }
}