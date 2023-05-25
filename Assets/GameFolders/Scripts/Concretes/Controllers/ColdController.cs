using System.Collections;
using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class ColdController : MonoBehaviour
    {
        private static GameData GameData => DataManager.Instance.GameData;

        private float _cold;
        private bool _isFreeze;

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
            if (_cold > 0)
            {
                _cold -= Time.deltaTime * GameData.FeelWarmCoefficient;
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.MaxCold);
            }
        }

        private void OnFeelColdHandler()
        {
            if(_isFreeze) return;
            
            if (_cold < GameData.MaxCold)
            {
                _cold += Time.deltaTime * GameData.FeelColdCoefficient;
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.MaxCold);
            }
            else
            {
                StartCoroutine(PlayerFreezeTime());
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.MaxCold);
            }
        }
        
        private IEnumerator PlayerFreezeTime()
        {
            _isFreeze = true;
            
            GameData.ColdSlowdown();

            float time = GameData.SlowdownTime;
            
            while (time > 0)
            {
                time -= Time.deltaTime;

                _cold -= Time.deltaTime * GameData.WarmUpPercentageAfterFreeze / GameData.SlowdownTime;
                
                DataManager.Instance.EventData.OnChangeColdFillAmount?.Invoke(_cold / GameData.MaxCold);

                yield return null;
            }
           
            GameData.ResetColdSpeed();
            
            _isFreeze = false;
        }
    }
}
