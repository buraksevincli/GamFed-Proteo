using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "PlayerData",menuName = "Data/Player Data")]
    public class PlayerData : ScriptableObject
    { 
        [Header("Player Movement Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        [Header("Energy Bar Settings")]
        [SerializeField] private float energyDecrease;
        [SerializeField] private float energyIncrease;
        public float MoveSpeed 
        {
            get
            { return moveSpeed; }
            set
            { moveSpeed = value; }
        }
        public float JumpForce => jumpForce;
        public float EnergyDecrease => energyDecrease;
        public float EnergyIncrease => energyIncrease;
    }
}
