using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

public class LevelTargetController : MonoSingleton<LevelTargetController>
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject gameCanvas;
    
    private bool _levelCompleted;
    public bool LevelCompleted => _levelCompleted;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _levelCompleted = true;
        }
    }

    public void LevelEnded()
    {
        dialoguePanel.SetActive(true);
        gameCanvas.SetActive(false);
    }
}
