using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes
{
    [RequireComponent(typeof(Button))]
    public class PushButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PushButtonOnClick);
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeStatuePushButton += OnChangeStatuePushButton;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeStatuePushButton -= OnChangeStatuePushButton;
        }

        private void PushButtonOnClick()
        {
            DataManager.Instance.EventData.OnCheckConnection?.Invoke();
        }

        private void OnChangeStatuePushButton(bool statue)
        {
            _button.interactable = statue;
        }
    }
}
