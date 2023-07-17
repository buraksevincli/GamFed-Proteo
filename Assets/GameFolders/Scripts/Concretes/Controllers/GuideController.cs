using GameFolders.Scripts.Concretes.UI;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class GuideController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform arrow;
        [SerializeField] private float distance = 5f;

        private void Update()
        {
            if (MissionPanel.Instance.MissionComplete)
            {
                target.gameObject.SetActive(true);
            }
            
            if (!target.gameObject.activeSelf)
            {
                arrow.gameObject.SetActive(false);
            }
            else
            {
                if (!arrow.gameObject.activeSelf)
                {
                    arrow.gameObject.SetActive(true);
                }
                
                GuideArrowController();
            }
        }

        private void GuideArrowController()
        {
            // Bu gameobject'i merkez alıyor.
            Vector2 center = transform.position;

            // Target objesinin pozisyonunu al
            Vector2 targetPosition = target.position;

            // Okun yönünü belirle
            Vector2 direction = targetPosition - center;
            direction.Normalize();

            // Okun pozisyonunu belirle
            Vector2 arrowPosition = center + direction * distance;
            arrow.position = arrowPosition;

            // Okun rotasyonunu belirle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
