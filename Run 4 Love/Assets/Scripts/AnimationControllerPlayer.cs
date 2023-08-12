using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement plMovement;
    [SerializeField] Animator animator;


    private void Awake()
    {
        plMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if(plMovement.isGrounded() == true && plMovement.isMoving == true)
        {
            animator.SetBool("IsMoving", true);
        } 
        else { animator.SetBool("IsMoving", false); }


        animator.SetBool("IsSlim", plMovement.isSlim);
    }

}
