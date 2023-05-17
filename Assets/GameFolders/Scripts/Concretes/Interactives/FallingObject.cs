using System;
using System.Collections;
using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Interactives
{
    public class FallingObject : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            PlayerController playerController = col.collider.GetComponent<PlayerController>();

            if (playerController)
            {
                this.gameObject.SetActive(false);
                DataManager.Instance.EventData.OnStunned?.Invoke();
            }
        }
    }
}
