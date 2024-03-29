using System;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Data/Event Data")]
    public class EventData : ScriptableObject
    {
        public Action<float> OnSpendEnergy { get; set; }
        public Action<float> OnGainEnergy { get; set; }
        public Action<float> OnChangeEnergyFillAmount { get; set; }
        public Action OnEnergyOver { get; set; }
        public Action OnCheckConnection { get; set; }
        public Action<bool> OnChangeStatuePushButton { get; set; }
        public Action<float> OnChangeColdFillAmount { get; set; }
        public Action OnFeelCold { get; set; } 
        public Action OnFeelWarm { get; set; }
        public Action OnStunned { get; set; }
        public Action OnClothesCollect { get; set; }
    }
}
