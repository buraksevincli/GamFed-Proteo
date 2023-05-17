using System.Collections;
using GameFolders.Scripts.Abstracts.Interacts;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class InteractSnowballMovement : InteractObject
    {
        [SerializeField] private float snowballMoveSpeed;
        
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
        
        public override void InteractObjectTrigger()
        {
            Debug.Log("kartopu çalıştı");
            StartCoroutine(InteractObjectTriggerAction());
        }

        private IEnumerator InteractObjectTriggerAction()
        {
            SnowballMovement();
            
            yield return _waitLifeTime;

            this.gameObject.SetActive(false);
        }

        private void SnowballMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            
            //_rigidbody2D.velocity = new Vector2(-DataManager.Instance.GameData.RollSpeed, _rigidbody2D.velocity.y);

            _rigidbody2D.angularVelocity = snowballMoveSpeed * 500;
        }
    }
}
