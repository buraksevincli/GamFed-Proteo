using UnityEngine;
using UnityEngine.Serialization;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "GameData",menuName = "Data/Game Data")]
    public class GameData : ScriptableObject
    { 
        private const float FallAnimationTime = 3;

        [Header("Player Movement Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        
        [Header("Energy Bar Settings")] 
        [SerializeField] private float maxEnergy;
        [SerializeField] private float forcedRestTime;
        [SerializeField] private float energyIncreaseCoefficient;
        [SerializeField] private float energyDecreaseCoefficient;
        [SerializeField] private float jumpEnergyDecreaseAmount;
        [SerializeField] private float energyIncreaseAmount;
        [SerializeField] private float excavableCost;

        [Header("Cold Bar Settings")]
        [SerializeField] private float maxCold;
        [SerializeField] private float feelColdCoefficient;
        [SerializeField] private float feelWarmCoefficient;
        [SerializeField] private float slowdownTime;
        [SerializeField] [Range(0, 1)] private float slowdownSpeedCoefficient;
        [SerializeField] private float warmUpPercentageAfterFreeze;

        [Header("Object To Be Thrown Settings")]
        [SerializeField] private float angle;
        [SerializeField] private float magnitude;
        [SerializeField] private float lifeTime;

        [Header("Falling Objects Settings")]
        [SerializeField] private float fallSpeed;
        [SerializeField] private float fallTimeAfterTrigger;
        [SerializeField] private float fallObjectStunTime;
        [SerializeField] private float fallObjectLifeTime;
        
        [Header("Snowball Objects Settings")]
        [SerializeField] private float snowballLifeTime;
        
        [Header("Crumbling Ground Settings")]
        [SerializeField] private float groundLifeTime;
        
        private float _speedCoefficient = 1f;

        public float EnergyDecreaseCoefficient => energyDecreaseCoefficient;
        public float JumpEnergyDecreaseAmount => jumpEnergyDecreaseAmount;
        public float EnergyIncreaseCoefficient => energyIncreaseCoefficient;
        public float MaxEnergy => maxEnergy;
        public float EnergyIncreaseAmount => energyIncreaseAmount;
        public float ForcedRestTime => forcedRestTime;
        public float Angle => angle;
        public float Magnitude => magnitude;
        public float LifeTime => lifeTime;
        public float MaxCold => maxCold;
        public float FeelColdCoefficient => feelColdCoefficient;
        public float FeelWarmCoefficient => feelWarmCoefficient;
        public float SlowdownTime => slowdownTime;
        public float WarmUpPercentageAfterFreeze => warmUpPercentageAfterFreeze;
        public float FallSpeed => fallSpeed;
        public float FallTimeAfterTrigger => fallTimeAfterTrigger;
        public float FallAlertAnimatorSpeed => FallAnimationTime / fallTimeAfterTrigger;
        public float FallObjectStunTime => fallObjectStunTime;
        public float SnowballLifeTime => snowballLifeTime;
        public float FallObjectLifeTime => fallObjectLifeTime;
        public float ExcavableCost => excavableCost;
        public float GroundLifeTime => groundLifeTime;
        
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
