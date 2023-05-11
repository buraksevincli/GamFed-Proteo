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
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;

    }
}
