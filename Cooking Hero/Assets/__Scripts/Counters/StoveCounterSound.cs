using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    private AudioSource audioSource;
    private StoveCounter stoveCounter;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        stoveCounter = GetComponentInParent<StoveCounter>();
    }

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStatsChangedEventArgs e)
    {
        bool playSound = e.currentState == StoveCounter.State.Fried || e.currentState == StoveCounter.State.Frying;
        if (playSound)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
