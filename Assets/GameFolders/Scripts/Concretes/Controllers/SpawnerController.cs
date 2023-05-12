using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Interactives;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private float minSpawnTime;
        [SerializeField] private float maxSpawnTime;
        
        private float _maxSpawnTime;
        private float _currentSpawnTime = 0f;

        private void Start()
        {
            GetRandomMaxTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            InteractAndCollectObject interactObject = SpawnerManager.Instance.GetPool();

            interactObject.transform.parent = this.transform;
            interactObject.transform.position = this.transform.position;
            interactObject.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
