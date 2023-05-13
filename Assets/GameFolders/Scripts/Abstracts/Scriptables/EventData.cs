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
        public Action OnFollowPlayer { get; set; }
    }
}
