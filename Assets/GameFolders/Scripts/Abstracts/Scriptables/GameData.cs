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
        [SerializeField] [Range(0, 1)] private float slowdownSpeedCoefficient;

        [Header("Energy Bar Settings")] 
        [SerializeField] private float energy;
        [SerializeField] private float forcedRestTime;
        [SerializeField] private float energyDecreaseCoefficient;
        [SerializeField] private float jumpEnergyDecreaseAmount;
        [SerializeField] private float energyIncreaseCoefficient;

        [Header("Object To Be Thrown Settings")]
        [SerializeField] private float angle;
        [SerializeField] private float magnitude;
        [SerializeField] private float lifeTime;
        
        private float _speedCoefficient = 1f;

        public float EnergyDecreaseCoefficient => energyDecreaseCoefficient;
        public float JumpEnergyDecreaseAmount => jumpEnergyDecreaseAmount;
        public float EnergyIncreaseCoefficient => energyIncreaseCoefficient;
        public float Energy => energy;
        public float ForcedRestTime => forcedRestTime;
        public float Angle => angle;
        public float Magnitude => magnitude;
        public float LifeTime => lifeTime;
        
        public float GetMoveSpeed()
        {
            return moveSpeed * _speedCoefficient;
        }

        public float GetJumpForce()
        {
            return jumpForce * _speedCoefficient;
        }

        public void Slowdown()
        {
            _speedCoefficient = slowdownSpeedCoefficient;
        }

        public void ResetSpeed()
        {
            _speedCoefficient = 1f;
        }
    }
}
