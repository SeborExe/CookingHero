using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;
    private ContainerCounter containerCounter;
    private const string OPEN_CLOSE = "OpenClose";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        containerCounter = GetComponentInParent<ContainerCounter>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs args)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
