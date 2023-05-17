using System;
using System.Collections;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FallingObjectController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private WaitForSeconds _waitLifeTime;
        private WaitForSeconds _waitFailTime;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _waitLifeTime = new WaitForSeconds(DataManager.Instance.GameData.FallObjectLifeTime);
            _waitFailTime = new WaitForSeconds(DataManager.Instance.GameData.FallTimeAfterTrigger);
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnFallTriggered += OnFallTriggeredHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnFallTriggered -= OnFallTriggeredHandler;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                DataManager.Instance.EventData.OnFallTriggered?.Invoke();
            }
        }

        private void OnFallTriggeredHandler()
        {
            StartCoroutine(FallTriggered());
        }

        private IEnumerator FallTriggered()
        {
            FallAllert();

            yield return _waitFailTime;

            FallObject();

            yield return _waitLifeTime;

            this.gameObject.SetActive(false);
        }
        
        private void FallAllert()
        {
            // Uyarı animasyonu.
        }
        
        private void FallObject()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody2D.gravityScale = DataManager.Instance.GameData.FallSpeed;
        }
    }
}
