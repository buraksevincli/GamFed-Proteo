using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class InteractAndCollectObject : MonoBehaviour
    {
        [SerializeField] private float angle;
        [SerializeField] private float magnitude;
        [SerializeField] private float lifeTime;

        private float _currentLifeTime = 0;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            ThrowObject();
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            
            if (_currentLifeTime > lifeTime)
            {
                _currentLifeTime = 0;
                SetThis();
            }
        }

        private void ThrowObject()
        {
            Vector2 force = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * magnitude;
            _rigidbody2D.AddForce(force);
        }

        public void SetThis()
        {
            SpawnerManager.Instance.SetPool(this);
            _currentLifeTime = 0;
        }
    }
}
