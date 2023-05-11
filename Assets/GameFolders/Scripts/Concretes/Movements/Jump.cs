using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Jump : IJump
    {
        private Rigidbody2D _rigidbody2D;

        public Jump(PlayerController playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }
        
        public void FixedTick(float jumpForce)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
