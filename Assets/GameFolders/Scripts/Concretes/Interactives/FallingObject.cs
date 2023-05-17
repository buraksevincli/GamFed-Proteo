using System.Collections;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class FallingObject : MonoBehaviour
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                StartCoroutine(FallTriggered());
            }
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            PlayerController playerController = col.collider.GetComponent<PlayerController>();

            if (playerController)
            {
                Debug.Log("çarptı");
                this.gameObject.SetActive(false);
                DataManager.Instance.EventData.OnStunned?.Invoke();
            }
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
