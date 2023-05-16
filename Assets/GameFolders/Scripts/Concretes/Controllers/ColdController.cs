using System;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class ColdController : MonoBehaviour
    {
        private static GameData GameData => DataManager.Instance.GameData;

        private float _cold;
        public float Cold => _cold;

        public bool IsFreeze => _cold >= 100;

        private void Awake()
        {
            _cold = 0;
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnFeelCold += OnFeelColdHandler;
            DataManager.Instance.EventData.OnFeelWarm += OnFeelWarmHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnFeelCold -= OnFeelColdHandler;
            DataManager.Instance.EventData.OnFeelWarm -= OnFeelWarmHandler;
        }

        private void OnFeelWarmHandler()
        {
            if (_cold < 0)
            {
                _cold -= Time.deltaTime * GameData.FeelWarmCoefficient;
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.Cold);
            }
        }

        private void OnFeelColdHandler()
        {
            if (_cold < 100)
            {
                _cold += Time.deltaTime * GameData.FeelColdCoefficient;
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.Cold);
            }
            else
            {
                DataManager.Instance.EventData.OnPlayerFreeze?.Invoke();
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.Cold);
            }
        }
    }
}
