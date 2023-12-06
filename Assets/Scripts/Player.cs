using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    //player movement (includes jump and running) and coroutine


    public float speedPerSecond = 4;
    public float jumpPower = 10;
    private float lateralMovement = 0;

    private float jumpTime = 0;
    public float maxJumpTime = 1;
    private bool isJumping = false;

    
    private bool canJump = true;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;


    Vector3 respawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("Hey you need a rigidbody!");
        }
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (PlayerPrefs.HasKey("PositionX"))
        {
            respawnPoint.x = PlayerPrefs.GetFloat("PositionX", 0);
            respawnPoint.y = PlayerPrefs.GetFloat("PositionY", 0);
            transform.position = respawnPoint;
        }
        else
        {
            respawnPoint = transform.position;
        }
    }




    // Update is called once per frame
    void Update()
    {


        lateralMovement = Input.GetAxis("Horizontal");

        isJumping = Input.GetAxis("Jump") > 0 ? true : false;

    }
    private void FixedUpdate()
    {

        if (transform.position.y < -14)
        {

            rb.velocity = Vector3.zero;
            transform.position = respawnPoint;
        }

        rb.velocity = new Vector2(lateralMovement * speedPerSecond * Time.fixedDeltaTime, rb.velocity.y);


        if (isJumping)
        {

            Vector3 feetPosition = transform.GetChild(0).position;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, 0.25f);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject == gameObject)
                    continue;

                rb.velocity = new Vector2(rb.velocity.x, 0);
                StartCoroutine(DoJump());
                
                break;
            }
        }


        if (rb.velocity.magnitude > 0.05f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    IEnumerator DoJump()
    {
        while(isJumping && jumpTime < maxJumpTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        jumpTime = 0;
    }




}