using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
        ChangeVisibility(false);
    }

    private void gameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            ChangeVisibility(true);
            scoreText.text = DeliveryManager.Instance.GetSuccessfulyAmount().ToString();
        }
        else
        {
            ChangeVisibility(false);
        }
    }

    private void ChangeVisibility(bool show)
    {
        gameObject.SetActive(show);
    }
}
