using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Flip : IFlip
    {
        private SpriteRenderer _spriteRenderer;
        
        public Flip(PlayerController playerController)
        {
            _spriteRenderer = playerController.GetComponentInChildren<SpriteRenderer>();
        }
        
        public void FixedTick(float direction)
        {
            if(direction == 0) return;

            if (direction > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
