using GameFolders.Scripts.Abstracts.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerAnimatorController : IAnimator
    {
        Animator _animator;

        public PlayerAnimatorController(PlayerController playerController)
        {
            _animator = playerController.GetComponentInChildren<Animator>();
        }

        public void SetRunAnimation(float horizontal)
        {
            _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        }

        public void SetJumpAnimation()
        {
            _animator.SetTrigger("Jump");
        }

        public void SetJumpAnimationValue(float jumpValue)
        {
            _animator.SetFloat("IsJump",Mathf.Abs(jumpValue));
        }

        public void StandDownAnimation()
        {
            _animator.SetBool("IsStand" , true);
            _animator.SetTrigger("Stand");
        }

        public void StandUpAnimation()
        {
            _animator.SetBool("IsStand" , false);
        }

        public void SetBarkAnimation()
        {
            _animator.SetTrigger("Bark");
        }
    }
}