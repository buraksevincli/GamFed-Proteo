using System;
using System.Collections;
using GameFolders.Scripts.Abstracts.Interacts;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class InteractIcicleMovement : InteractObject
    {
        private Rigidbody2D _rigidbody2D;

        private WaitForSeconds _waitLifeTime;
        private WaitForSeconds _waitFallTime;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _waitLifeTime = new WaitForSeconds(DataManager.Instance.GameData.FallObjectLifeTime);
            _waitFallTime = new WaitForSeconds(DataManager.Instance.GameData.FallTimeAfterTrigger);
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

        public override void InteractObjectTrigger()
        {
            StartCoroutine(FallObjectTriggerAction());
        }

        private IEnumerator FallObjectTriggerAction()
        {
            FallObjectAlert();

            yield return _waitFallTime;
            
            FallObjectMovement();

            yield return _waitLifeTime;

            this.gameObject.SetActive(false);
        }

        private void FallObjectMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody2D.gravityScale = DataManager.Instance.GameData.FallSpeed;
        }

        private void FallObjectAlert()
        {
            //Fall uyarı animasyonu.
        }
    }
}
