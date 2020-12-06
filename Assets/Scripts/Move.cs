using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;

    Animator thisAnim;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigidBody;
    bool isIdle = true;

    float distToGround;
    private BoxCollider2D boyCollider;

    bool onlyOnce = true; //2nd Jump only once
    //private bool isCoroutineExecuting = false;
    public float Points;
    private float gameTime;
    //private bool gameStart;
    

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boyCollider = GetComponent<BoxCollider2D>();
        distToGround = boyCollider.bounds.extents.y;
        thisAnim.ResetTrigger("Death");
        //Points = gameTime; //don't have game start with gameTime counting instantly
        //gameStart = false;
    }
    
    //replace this with OnCollision?
    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up,distToGround);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = Mathf.Floor(Time.timeSinceLevelLoad * 10);
        //Idle
        if (isIdle)
        {
            isIdle = true;
            thisAnim.SetBool("Idle", true);
            if (Input.GetButton("Jump"))
                isIdle = false;
        }

        //First Jump
        else if (Input.GetButton("Jump") && IsGrounded())
        {
            isIdle = false;
            //gameStart = true;
            thisAnim.ResetTrigger("Running");
            thisAnim.SetTrigger("Jumping");

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            onlyOnce = true;
        }

        //Double Jump
        else if (Input.GetButtonDown("Jump") && !IsGrounded() && onlyOnce)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            thisAnim.ResetTrigger("Jumping");
            thisAnim.SetTrigger("2ndJump");
            onlyOnce = false;
        }

        //Running
        else
        {
            thisAnim.SetBool("Idle", false);
            if (IsGrounded())
            { 
                thisAnim.ResetTrigger("Jumping");
                thisAnim.ResetTrigger("2ndJump");
                thisAnim.SetTrigger("Running");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Obstacle(Clone)" || collision.gameObject.name == "DeathFall")
        {
            //Dying();
            //Points += gameTime;
            //Debug.Log("Game Ending...Your Points: " + Points);
            thisAnim.ResetTrigger("Jumping");
            thisAnim.ResetTrigger("Running");
            thisAnim.SetTrigger("Death");
            StartCoroutine(WaitBeforeGameEnd());
            
        }
        else if (collision.gameObject.name == "Points(Clone)")
        {
            Destroy(collision.gameObject);

            Points += 100;
        }
    }

    IEnumerator WaitBeforeGameEnd()
    {
        yield return new WaitForSeconds(.3f);
        gameManager.GameOver();
    }
}