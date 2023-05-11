using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool JumpButtonDown => Input.GetButtonDown("Jump");
    }
}

