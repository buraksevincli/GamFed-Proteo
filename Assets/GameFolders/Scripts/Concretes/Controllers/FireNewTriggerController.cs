using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FireNewTriggerController : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                DataManager.Instance.EventData.OnSpendEnergy?.Invoke(DataManager.Instance.GameData.EnergyDecreaseCoefficient * 4 * Time.deltaTime);
            }
        }
    }
}
