using UnityEngine;

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
        [SerializeField] [Range(0, 1)] private float coldSlowdownSpeedCoefficient;
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
        
        [Header("Wind Settings")]
        [SerializeField] [Range(0, 1)] private float windSlowdownSpeedCoefficient;
        [SerializeField] [Range(1, 3)] private float windSpeedUpCoefficient;
        
        private float _coldSpeedCoefficient = 1f;
        private float _windSpeedCoefficient = 1f;

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
            return moveSpeed * _coldSpeedCoefficient * _windSpeedCoefficient;
        }

        public float GetJumpForce()
        {
            return jumpForce * _coldSpeedCoefficient;
        }

        public void ColdSlowdown()
        {
            _coldSpeedCoefficient = coldSlowdownSpeedCoefficient;
        }

        public void ResetColdSpeed()
        {
            _coldSpeedCoefficient = 1f;
        }

        public void WindSlowdown()
        {
            _windSpeedCoefficient = windSlowdownSpeedCoefficient;
        }

        public void WindSpeedUp()
        {
            _windSpeedCoefficient = windSpeedUpCoefficient;
        }

        public void ResetWindSpeed()
        {
            _windSpeedCoefficient = 1f;
        } 
    }
}
