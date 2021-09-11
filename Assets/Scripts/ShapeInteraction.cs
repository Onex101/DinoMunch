using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeInteraction : MonoBehaviour
{
    private List<Shape> stomach;
    // Start is called before the first frame update
    void Start()
    {
        stomach = new List<Shape>();
    }

    // Update is called once per frame
    void Update()
    {
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
            // Add sounds in later
            //eatSound.Play();
            Destroy(collision.gameObject);
        }
    }

    private void DigestShape(SpriteRenderer shape)
    {
        string colour;
        string type;

        if (shape.color == Color.red)
        {
            colour = "Red";
        }
        else if (shape.color == Color.blue)
        {
            colour = "Blue";
        }
        else if (shape.color == Color.green)
        {
            colour = "Green";
        }
        else if (shape.color == Color.yellow)
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
