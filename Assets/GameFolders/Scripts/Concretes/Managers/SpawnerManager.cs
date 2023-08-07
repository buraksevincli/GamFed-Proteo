using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Interactives;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class SpawnerManager : MonoSingleton<SpawnerManager>
    {
        [SerializeField] private InteractAndCollectObject[] interactObjectPrefab;

        private readonly Queue<InteractAndCollectObject> _interactPool = new Queue<InteractAndCollectObject>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < interactObjectPrefab.Length; i++)
            {
                InteractAndCollectObject interactObject = Instantiate(interactObjectPrefab[i]);
                interactObject.gameObject.SetActive(false);
                interactObject.transform.parent = transform;

                _interactPool.Enqueue(interactObject);
            }
        }

        public void SetPool(InteractAndCollectObject interactObject)
        {
            interactObject.gameObject.SetActive(false);
            interactObject.transform.parent = this.transform;
            
            _interactPool.Enqueue(interactObject);
        }

        public InteractAndCollectObject GetPool()
        {
            if (_interactPool.Count == 0)
            {
                InitializePool();
            }

            return _interactPool.Dequeue();
        }
    }
}

