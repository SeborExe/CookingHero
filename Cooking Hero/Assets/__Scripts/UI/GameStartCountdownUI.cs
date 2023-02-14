using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
        ChangeVisibility(false);
    }

    private void Update()
    {
        countdownText.text = GameManager.Instance.GetCountdownToStartTimer().ToString("#0");
    }

    private void gameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            ChangeVisibility(true);
        }
        else
        {
            ChangeVisibility(false);
        }
    }

    private void ChangeVisibility(bool show)
    {
        countdownText.gameObject.SetActive(show);
    }
}
