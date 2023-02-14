using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnFlashingUI : MonoBehaviour
{
    private StoveCounter stoveCounter;
    private Animator animator;

    private const string IS_FLASHING = "IsFlashing";

    private void Awake()
    {
        stoveCounter = GetComponentInParent<StoveCounter>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        stoveCounter.OnProgressChange += StoveCounter_OnProgressChange;

        animator.SetBool(IS_FLASHING, false);
    }

    private void StoveCounter_OnProgressChange(object sender, IHasProgress.OnProgressChangeEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        animator.SetBool(IS_FLASHING, show);
    }
}
