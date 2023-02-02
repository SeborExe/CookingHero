using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    private CleanCounter cleanCounter;

    [SerializeField] private GameObject visualGameObject;

    private void Awake()
    {
        cleanCounter = GetComponentInParent<CleanCounter>();
    }

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs args)
    {
        if (args.selectedCounter == cleanCounter)
        {
            ChangeVisualVisibility(true);
        }
        else
        {
            ChangeVisualVisibility(false);
        }
    }

    private void ChangeVisualVisibility(bool show)
    {
        visualGameObject.SetActive(show);
    }
}
