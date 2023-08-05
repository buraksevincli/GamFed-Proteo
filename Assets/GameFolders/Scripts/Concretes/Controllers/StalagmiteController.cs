using System.Collections;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class StalagmiteController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                StartCoroutine(SlowdownCoroutine());
            }
        }

        private IEnumerator SlowdownCoroutine()
        {
            DataManager.Instance.GameData.ColdSlowdown();

            yield return new WaitForSeconds(3f);
            
            DataManager.Instance.GameData.ResetColdSpeed();
        }
    }
}
