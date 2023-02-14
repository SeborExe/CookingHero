using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    private Animator animator;

    private const string NUMBER_POPUP = "NumberPopup";

    [SerializeField] private TMP_Text countdownText;

    private int previousCountdownNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
        ChangeVisibility(false);
    }

    private void Update()
    {
        int countDownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countDownNumber.ToString("#0");

        if (previousCountdownNumber != countDownNumber)
        {
            previousCountdownNumber = countDownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
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
