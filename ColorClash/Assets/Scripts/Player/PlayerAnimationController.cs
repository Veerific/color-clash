using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Player player;


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsWalking", player.isMoving);
    }
}
