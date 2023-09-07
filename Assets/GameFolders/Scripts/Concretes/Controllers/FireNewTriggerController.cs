using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FireNewTriggerController : MonoBehaviour
    {
        [SerializeField][Range(2.6f,10)] private float energyDecreaseCoefficient = 4;
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                DataManager.Instance.EventData.OnSpendEnergy?.Invoke(DataManager.Instance.GameData.EnergyDecreaseCoefficient * energyDecreaseCoefficient * Time.deltaTime);
            }
        }
    }
}
