using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;

    bool isGrounded;

    public bool islevelClear;
    public bool startAgain;
    CountLevel cl;

    public bool GetStartAgain()
    {
        return startAgain;
    }

    public bool GetisLevelClear()
    {
        return islevelClear;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = FindObjectOfType<CountLevel>();
        StartCoroutine(Checknumber());
    }
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(move, 0) * speed);

        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded == true)
            {
                rb.AddForce(new Vector2(0, jump));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Obstacle")
        {
            Destroy(gameObject, 0.5f);
        }
        else if(collision.tag=="EndPoint")
        {
            transform.position = Vector2.zero;
            StartCoroutine(RestartLevel());

            startAgain = true;
            
        }
    }
    IEnumerator RestartLevel()
    {
        
        islevelClear = true;
        yield return new WaitForSeconds(1f);
        islevelClear = false;
    }
    IEnumerator Checknumber()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (cl.GetisNUmber() < 15)
            {

                StartCoroutine(RestartLevel());
                startAgain = true;
            }
            
        }
    }

   
}
