using System;
using System.Collections;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FallingObjectController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
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

            yield return new WaitForSeconds(DataManager.Instance.GameData.FallTimeAfterTrigger);

            FallObject();
        }
        
        private void FallAllert()
        {
            // Uyarı animasyonu.
        }
        
        private void FallObject()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -DataManager.Instance.GameData.FallSpeed);
        }
    }
}
