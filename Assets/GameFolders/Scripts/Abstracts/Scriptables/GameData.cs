using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "GameData",menuName = "Data/Game Data")]
    public class GameData : ScriptableObject
    { 
        [Header("Player Movement Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        [Header("Energy Bar Settings")] 
        [SerializeField] private float energy;
        [SerializeField] private float forcedRestTime;
        [SerializeField] private float energyDecreaseCoefficient;
        [SerializeField] private float jumpEnergyDecreaseAmount;
        [SerializeField] private float energyIncreaseCoefficient;
        
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public float EnergyDecreaseCoefficient => energyDecreaseCoefficient;
        public float JumpEnergyDecreaseAmount => jumpEnergyDecreaseAmount;
        public float EnergyIncreaseCoefficient => energyIncreaseCoefficient;
        public float Energy => energy;
        public float ForcedRestTime => forcedRestTime;
    }
}
