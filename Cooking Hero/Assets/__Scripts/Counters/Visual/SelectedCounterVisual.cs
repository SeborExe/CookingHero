using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    private BaseCounter baseCounter;

    [SerializeField] private GameObject[] visualGameObjects;

    private void Awake()
    {
        baseCounter = GetComponentInParent<BaseCounter>();
    }

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs args)
    {
        if (args.selectedCounter == baseCounter)
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
        foreach (GameObject visualGameObject in visualGameObjects)
        {
            visualGameObject.SetActive(show);
        }
    }
}
