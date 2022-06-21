using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Citizen_Animation citizenAnimation;
    private float velocityX;
    private float velocityY;
    private Rigidbody2D rb;

    private int randomNum;

    private void Awake()
    {
        citizenAnimation = GetComponent<Citizen_Animation>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(RandomWalk());
    }
    private void MoveUp()
    {
        velocityX = 0;
        velocityY = 1;
        citizenAnimation.SetAnimation(velocityX, velocityY);
    }
    private void MoveDown()
    {
        velocityX = 0;
        velocityY = -1;
        citizenAnimation.SetAnimation(velocityX, velocityY);
    }
    private void MoveLeft()
    {
        velocityX = -1;
        velocityY = 0;
        citizenAnimation.SetAnimation(velocityX, velocityY);
    }
    private void MoveRight()
    {
        velocityX = 1;
        velocityY = 0;
        citizenAnimation.SetAnimation(velocityX, velocityY);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocityX, velocityY) * movementSpeed;
    }

    private IEnumerator RandomWalk()
    {
        randomNum = Random.Range(1, 5);

        float randomTime = Random.Range(1, 4);
        if(randomNum == 1)
        {
            MoveUp();
        }
        else if(randomNum == 2)
        {
            MoveDown();
        }
        else if(randomNum == 3)
        {
            MoveLeft();
        }
        else if(randomNum == 4)
        {
            MoveRight();
        }
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(Idle());
    }

    private IEnumerator Idle()
    {
        float randomTime = Random.Range(3, 7);

        velocityX = 0;
        velocityY = 0;
        citizenAnimation.SetAnimation(0, 0);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(RandomWalk());
    }
}
