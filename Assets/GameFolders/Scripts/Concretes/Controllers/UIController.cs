using System;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class UIController : MonoSingleton<UIController>
    {
        [SerializeField] private Button pushButton;
        
        private void OnEnable()
        {
            pushButton.onClick?.AddListener(PushButtonOnClick);
        }

        private void OnDisable()
        {
            pushButton.onClick?.AddListener(PushButtonOnClick);
        }

        private void PushButtonOnClick()
        {
            DataManager.Instance.EventData.OnFollowPlayer?.Invoke();
        }
    }
}
