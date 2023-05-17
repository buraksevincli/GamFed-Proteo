using System;
using GameFolders.Scripts.Abstracts.Interacts;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class FallingManager : MonoBehaviour
    {
        [SerializeField] private FallObject fallObject;

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnFallObjectTriggered += OnFallObjectTriggeredHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnFallObjectTriggered -= OnFallObjectTriggeredHandler;
        }

        private void OnFallObjectTriggeredHandler()
        {
            fallObject.FallObjectTrigger();
        }
    }
}
