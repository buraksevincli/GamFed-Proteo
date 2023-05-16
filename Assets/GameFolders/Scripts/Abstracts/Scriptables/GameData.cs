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
        [SerializeField] private float energyIncreaseAmount;

        [Header("Cold Bar Settings")]
        [SerializeField] private float cold;
        [SerializeField] private float feelColdCoefficient;
        [SerializeField] private float feelWarmCoefficient;
        [SerializeField] private float slowdownTime;
        [SerializeField] [Range(0, 1)] private float slowdownSpeedCoefficient;
        [SerializeField] private float warmUpPercentageAfterFreeze;

        [Header("Object To Be Thrown Settings")]
        [SerializeField] private float angle;
        [SerializeField] private float magnitude;
        [SerializeField] private float lifeTime;
        
        private float _speedCoefficient = 1f;

        public float EnergyDecreaseCoefficient => energyDecreaseCoefficient;
        public float JumpEnergyDecreaseAmount => jumpEnergyDecreaseAmount;
        public float EnergyIncreaseCoefficient => energyIncreaseCoefficient;
        public float Energy => energy;
        public float EnergyIncreaseAmount => energyIncreaseAmount;
        public float ForcedRestTime => forcedRestTime;
        public float Angle => angle;
        public float Magnitude => magnitude;
        public float LifeTime => lifeTime;
        public float Cold => cold;
        public float FeelColdCoefficient => feelColdCoefficient;
        public float FeelWarmCoefficient => feelWarmCoefficient;
        public float SlowdownTime => slowdownTime;
        public float WarmUpPercentageAfterFreeze => warmUpPercentageAfterFreeze;

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
