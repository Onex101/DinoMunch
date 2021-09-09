using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioSource jumpSound;
    private Rigidbody2D rigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical");

        // Allows dino to jump only when grounded (and theoretically at the peak of a jump? Might be a problem later)
        if (verticalInput > 0 && rigidBodyComponent.velocity.y == 0)
        {
            jumpSound.Play();
            rigidBodyComponent.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
        }
        
    }
}
