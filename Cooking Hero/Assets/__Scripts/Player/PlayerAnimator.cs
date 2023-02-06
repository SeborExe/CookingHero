using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Player player;

    private const string IS_WALKING = "IsWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
