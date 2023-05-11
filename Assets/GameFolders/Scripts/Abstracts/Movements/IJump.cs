using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Movements
{
    public interface IJump
    {
        void FixedTick(float jumpForce);
    }
}
