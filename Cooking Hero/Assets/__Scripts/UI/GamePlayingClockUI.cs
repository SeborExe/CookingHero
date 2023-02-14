using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image clockImage;

    private void Update()
    {
        clockImage.fillAmount =  GameManager.Instance.GetPlayingTimerNormalized();
    }
}
