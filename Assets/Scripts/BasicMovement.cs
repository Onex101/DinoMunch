using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public bool isGrounded = false;
    public float jumpHeight = 2.0f;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    // Update is called once per frame
    void Update()
    {
        Jump();
        // animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        // Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        // transform.position = transform.position + horizontal * Time.deltaTime;
        
    }

    void Jump () {

        if (Input.GetButtonDown("Jump") && isGrounded == true){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f , jumpHeight), ForceMode2D.Impulse);
        }

        // if (isJumping == true){
        //     if (jumpTimeCounter > 0){
        //         gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f , jumpHeight), ForceMode2D.Impulse);
        //         jumpTimeCounter -= Time.deltaTime;
        //     } else {
        //         isJumping = false;
        //     }
        // }

        if (Input.GetButtonUp("Jump") && isJumping == true){
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f , 0f);
            isJumping = false;
        }
    }
}
