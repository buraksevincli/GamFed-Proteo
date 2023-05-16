using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Mover : IMover
    {
        private Rigidbody2D _rigidbody2D;

        public Mover(PlayerController playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }
        public void FixedTick(float horizontal, float moveSpeed)
        {
            _rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, _rigidbody2D.velocity.y);
        }

        public float GetVelocityY()
        {
            return _rigidbody2D.velocity.y;
        }
    }
}
