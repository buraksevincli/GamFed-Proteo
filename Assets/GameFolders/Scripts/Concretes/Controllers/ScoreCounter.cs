using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoSingleton<ScoreCounter>
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private GameObject gamePanel;

    private int _score;

    public void SetSocialScore()
    { 
        switch (_score)
        {
            case <20:
                _score += 1;
                scoreText.text = _score.ToString();

                if (_score == 20)
                {
                    levelEndPanel.SetActive(true);
                    gamePanel.SetActive(false);
                }
                break;
        }
    }

}
