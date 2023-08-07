using System.Collections;
using GameFolders.Scripts.Concretes.Managers;
using TMPro;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UI
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private GameObject continueButton;
        [SerializeField] private float writeSpeed;
        [SerializeField] private string[] dialogueSentences;
        
        private int _story;
        
        private void OnEnable()
        {
            StartCoroutine(DialogueMethod());
        }

        private void Update()
        {
            if (dialogueText.text == dialogueSentences[_story])
            {
                continueButton.SetActive(true);
            }
        }

        IEnumerator DialogueMethod()
        {
            dialogueText.text = "";
            
            foreach (char letter in dialogueSentences[_story].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(writeSpeed);
            }
        }

        public void NextSentences()
        {
            if (_story < dialogueSentences.Length -1)
            {
                _story++;
                dialogueText.text = "";
                StartCoroutine(DialogueMethod());
            }
            else
            {
                GameManager.Instance.NextScene();
            }
        }
    }
}
