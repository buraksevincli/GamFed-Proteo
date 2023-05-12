using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Utilities
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private bool dontDestroyOnLoad;
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}