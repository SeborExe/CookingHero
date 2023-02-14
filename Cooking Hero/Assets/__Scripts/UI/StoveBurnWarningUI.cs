using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnWarningUI : MonoBehaviour
{
    private StoveCounter stoveCounter;

    private void Awake()
    {
        stoveCounter = GetComponentInParent<StoveCounter>();
    }

    private void Start()
    {
        stoveCounter.OnProgressChange += StoveCounter_OnProgressChange;

        ChangeVisibility(false);
    }

    private void StoveCounter_OnProgressChange(object sender, IHasProgress.OnProgressChangeEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        ChangeVisibility(show);
    }

    private void ChangeVisibility(bool show)
    {
        gameObject.SetActive(show);
    }
}
