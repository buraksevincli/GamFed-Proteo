using System;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Managers;
using TMPro;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UI
{
    public class MissionPanel : MonoSingleton<MissionPanel>
    {
        [SerializeField] private TMP_Text clothesText;

        public bool MissionComplete { get; set; }
        
        private int _clothesScore;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnClothesCollect += OnClothesCollectHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnClothesCollect -= OnClothesCollectHandler;
        }

        private void Update()
        {
            if (_clothesScore == 5)
            {
                MissionComplete = true;
            }
        }

        private void OnClothesCollectHandler()
        {
            _clothesScore += 1;
            clothesText.text = $"{_clothesScore}/5";
        }
    }
}
