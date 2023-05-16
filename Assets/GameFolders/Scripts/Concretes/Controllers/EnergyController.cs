using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnergyController : MonoBehaviour
    {
        private static GameData GameData => DataManager.Instance.GameData;

        private float _energy;

        public float Energy => _energy;

        public bool IsHaveEnergy => _energy > 0;

        private void Start()
        {
            _energy = GameData.Energy;
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnSpendEnergy += OnSpendEnergyHandler;
            DataManager.Instance.EventData.OnGainEnergy += OnGainEnergyHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnSpendEnergy -= OnSpendEnergyHandler;
            DataManager.Instance.EventData.OnGainEnergy -= OnGainEnergyHandler;
        }

        private void OnSpendEnergyHandler(float energy)
        {
            if (_energy > 0)
            {
                _energy = Mathf.Clamp((_energy - energy), 0, GameData.Energy);
                DataManager.Instance.EventData.OnChangeEnergyFillAmount?.Invoke(_energy / GameData.Energy);
            }
            else
            {
                DataManager.Instance.EventData.OnEnergyOver?.Invoke();
                DataManager.Instance.EventData.OnChangeEnergyFillAmount?.Invoke(0);
            }
        }

        private void OnGainEnergyHandler(float energy)
        {
            if (energy < GameData.Energy)
            {
                _energy = Mathf.Clamp((_energy + energy), 0, GameData.Energy);
                DataManager.Instance.EventData.OnChangeEnergyFillAmount?.Invoke(_energy / GameData.Energy);
            }
            else
            {
                _energy = GameData.Energy;
                DataManager.Instance.EventData.OnChangeEnergyFillAmount?.Invoke(1);
            }
        }
    }
}