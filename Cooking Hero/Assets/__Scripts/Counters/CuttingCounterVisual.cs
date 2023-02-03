using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator animator;
    private CuttingCounter cuttingCounter;
    private const string CUT = "Cut";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cuttingCounter = GetComponentInParent<CuttingCounter>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
