using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Movements
{
    public interface IMover
    {
        void FixedTick(float horizontal, float moveSpeed);
    }
}
