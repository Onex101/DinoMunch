using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 3f;
    public float jumpSpeed = 4f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D> ();
    }
  

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;
        
        movement = Input.GetAxis ("Horizontal");
        if (movement > 0f) {
          rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f) {
          rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
        } 
        else {
          rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
        }
        if(Input.GetButtonDown ("Jump")){
          rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
        }

    }
}
