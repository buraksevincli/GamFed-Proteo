using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        
        bool JumpButtonDown { get; }
    }
}

