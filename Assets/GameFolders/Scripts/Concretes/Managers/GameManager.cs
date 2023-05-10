using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviourObjects<GameManager>
    {
        private void Awake()
        {
            SingletonThisGameObject(this);
        }
    }
}