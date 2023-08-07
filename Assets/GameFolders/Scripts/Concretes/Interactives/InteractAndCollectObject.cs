using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class InteractAndCollectObject : MonoBehaviour
    {
        public float direction;
        public float angle;
        
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                ScoreCounter.Instance.SetSocialScore();
                SetThis();
            }
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            
            if (_currentLifeTime > DataManager.Instance.GameData.LifeTime)
            {
                _currentLifeTime = 0;
                SetThis();
            }
        }

        private void ThrowObject()
        {
            Vector2 force = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad), 
                Mathf.Sin(angle * Mathf.Deg2Rad)) * 
                            DataManager.Instance.GameData.Magnitude;
            
            _rigidbody2D.AddForce(force * direction);
        }

        private void SetThis()
        {
            SpawnerManager.Instance.SetPool(this);
            _currentLifeTime = 0;
        }
    }
}
