using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particleGameObject;

    private StoveCounter stoveCounter;

    private void Awake()
    {
        stoveCounter = GetComponentInParent<StoveCounter>();
    }

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStatsChangedEventArgs e)
    {
        bool showVisual = e.currentState == StoveCounter.State.Frying || e.currentState == StoveCounter.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particleGameObject.SetActive(showVisual);
    }
}
