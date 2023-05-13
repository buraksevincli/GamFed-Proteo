using System;
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

        public void SetRestAnimation()
        {
            _animator.SetTrigger("Sit");
            _animator.SetBool("IsStand" , true);
        }

        public void StandUpAnimation()
        {
            _animator.SetBool("IsStand" , false);
        }
    }
}