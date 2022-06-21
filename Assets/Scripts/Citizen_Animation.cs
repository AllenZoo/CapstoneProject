using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen_Animation : MonoBehaviour
{
    private Animator animator;

    private float lastVelocityX;
    private float lastVelocityY;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        lastVelocityX = 0;
        lastVelocityY = 0;
    }

    public void SetAnimation(float velocityX, float velocityY)
    {
        //If idle
        if (velocityX == 0 && velocityY == 0)
        {
            animator.SetFloat("velocityX", lastVelocityX);
            animator.SetFloat("velocityY", lastVelocityY);
            animator.Play("Idle_State");
        }
        //If Moving
        else if (Mathf.Abs(velocityX) >= 1 || Mathf.Abs(velocityY) >= 1)
        {
            lastVelocityX = velocityX;
            lastVelocityY = velocityY;

            animator.Play("Moving_State");
            animator.SetFloat("velocityX", velocityX);
            animator.SetFloat("velocityY", velocityY);
        }
    }
}
