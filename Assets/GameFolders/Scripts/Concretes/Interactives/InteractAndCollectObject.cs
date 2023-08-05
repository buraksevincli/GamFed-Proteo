using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class InteractAndCollectObject : MonoBehaviour
    {
        public int direction;
        
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
            
            if (_currentLifeTime > DataManager.Instance.GameData.LifeTime)
            {
                _currentLifeTime = 0;
                SetThis();
            }
        }

        private void ThrowObject()
        {
            Vector2 force = new Vector2(
                Mathf.Cos(DataManager.Instance.GameData.Angle * Mathf.Deg2Rad), 
                Mathf.Sin(DataManager.Instance.GameData.Angle * Mathf.Deg2Rad)) * 
                            DataManager.Instance.GameData.Magnitude;
            
            _rigidbody2D.AddForce(force * direction);
        }

        public void SetThis()
        {
            SpawnerManager.Instance.SetPool(this);
            _currentLifeTime = 0;
        }
    }
}
