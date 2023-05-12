using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Interactives;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class InteractAndCollectObject : MonoBehaviour, IInteractive
    {
        public void Interactive()
        {
            Destroy(this.gameObject);
        }
    }
}
