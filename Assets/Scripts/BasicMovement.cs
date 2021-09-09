using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource eatSound;
    [SerializeField] private AudioSource deathSound;
    private Rigidbody2D rigidBodyComponent;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        // left shift resets dino
        if (Input.GetButtonDown("Fire3"))
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        // Testing game over scenario
        if (transform.position.y < -5 && !isDead)
        {
            isDead = true;
            StartCoroutine(HandlePlayerDeath());
        }
    }

    // Testing devouring of shaped goodness
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Arbitrarily assigned 10 as Shape Layer
        if (collision.gameObject.layer == 10)
        {
            eatSound.Play();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // When touching the ground
        // Cant quite get it working right. Scalings weird.
        if (collision.gameObject.layer == 9)
        {
            float verticalInput = Input.GetAxis("Vertical");
            if (verticalInput > 0 && rigidBodyComponent.velocity.y == 0)
            {
                jumpSound.Play();
                rigidBodyComponent.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private IEnumerator HandlePlayerDeath()
    {
        deathSound.Play();
        yield return new WaitForSeconds(0.5f);
        Respawn();
        isDead = false;
    }

    private void Respawn()
    {
        rigidBodyComponent.velocity = new Vector2(0, 0);
        transform.position = new Vector2(-0.691f, -0.237f);
    }
}
