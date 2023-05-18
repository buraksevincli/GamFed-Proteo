using GameFolders.Scripts.Abstracts.Interacts;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class InteractObjectController : MonoBehaviour
    {
        [SerializeField] private InteractObject interactObject;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (interactObject.gameObject.activeSelf)
            {
                if (col.TryGetComponent(out PlayerController playerController))
                {
                    interactObject.InteractObjectTrigger();
                }
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}