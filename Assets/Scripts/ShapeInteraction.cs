using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeInteraction : MonoBehaviour
{
    private List<Shape> stomach;
    [SerializeField] private AudioClip eatAudioClip;
    private AudioSource eatAudioSource;
    public GameObject player;

    private void Awake()
    {
        eatAudioSource = gameObject.AddComponent<AudioSource>();
        eatAudioSource.clip = eatAudioClip;
        eatAudioSource.playOnAwake = false;
        player = GameObject.Find("Player(Clone)");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player.tag = "Blue Dino";
        stomach = new List<Shape>();
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i].tag != "Blue Dino")
                sprites[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary feature. Lists shapes eaten
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string stomachLog = "";
            foreach (Shape shape in stomach)
            {
                stomachLog += $"{shape.colour} {shape.type}, ";
            }

            Debug.Log($"Stomach currently digesting: {stomachLog}");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            DigestShape(collision.gameObject.GetComponent<SpriteRenderer>());
            eatAudioSource.Play();
            Destroy(collision.gameObject);
        }
    }

    private void DigestShape(SpriteRenderer shape)
    {
        string colour;
        string type;
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        if (shape.color == CustomColors.Red)
        {
            colour = "Red";
        }
        else if (shape.color == CustomColors.Blue)
        {
            colour = "Blue";
        }
        else if (shape.color == CustomColors.Green)
        {
            colour = "Green";
        }
        else if (shape.color == CustomColors.Yellow)
        {
            colour = "Yellow";
        }
        else
        {
            colour = "White";
        }

        type = shape.sprite.name;
        if (type == "Hexagon Flat-Top")
        {
            type = "Hexagon";
        }

        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i].tag == colour + " Dino")
            {
                sprites[i].enabled = true;
                player.tag = colour + " Dino";
            }
            else {
                sprites[i].enabled = false;
            } 
        }

        stomach.Add(new Shape(colour, type));
    }
}

class Shape
{
    public string colour { get; private set; }
    public string type { get; private set; }

    public Shape(string colour, string type)
    {
        this.colour = colour;
        this.type = type;
    }
}
