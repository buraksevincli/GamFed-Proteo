using System;
using System.Collections;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class SnowballObject : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private WaitForSeconds _waitLifeTime;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _waitLifeTime = new WaitForSeconds(DataManager.Instance.GameData.SnowballLifeTime);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            PlayerController playerController = col.collider.GetComponent<PlayerController>();

            if (playerController)
            {
                this.gameObject.SetActive(false);
                DataManager.Instance.EventData.OnStunned?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                StartCoroutine(SnowballAction());
            }
        }

        private void SnowballMove()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            
            _rigidbody2D.velocity = new Vector2(-DataManager.Instance.GameData.RollSpeed, _rigidbody2D.velocity.y);
        }

        private IEnumerator SnowballAction()
        {
            SnowballMove();
            yield return _waitLifeTime;
            this.gameObject.SetActive(false);
        }
    }
}
