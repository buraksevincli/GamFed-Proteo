using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Flip : IFlip
    {
        private Transform _transform;
        
        public Flip(PlayerController playerController)
        {
            _transform = playerController.transform;
        }
        
        public void FixedTick(float direction)
        {
            if(direction == 0) return;

            if (direction > 0)
            {
                _transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                _transform.localScale = new Vector3(-1, 1, 1);

            }
        }
    }
}
