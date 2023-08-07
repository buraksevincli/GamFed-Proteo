using System.Collections;
using GameFolders.Scripts.Abstracts.Interacts;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class InteractCrumblingGroundMovement : InteractObject
    {
        private WaitForSeconds _waitLifeTime;

        private void Awake()
        {
            _waitLifeTime = new WaitForSeconds(DataManager.Instance.GameData.GroundLifeTime);
        }

        public override void InteractObjectTrigger()
        {
            StartCoroutine(InteractObjectTriggerAction());
        }
        
        private IEnumerator InteractObjectTriggerAction()
        {
            CrumblingEffect();

            yield return _waitLifeTime;

            this.gameObject.SetActive(false);
        }

        private void CrumblingEffect()
        {
            //Zemin parçalanma efekti yazılacak.
        }
    }
}
