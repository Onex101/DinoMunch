using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateShapes : MonoBehaviour
{
    [SerializeField] private GameObject[] shapes;
    private Color[] colours = { Color.red, Color.blue, Color.yellow, Color.green };
    private float gameSpeed = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShape", 5, 2);
        InvokeRepeating("IncreaseSpeed", 30, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnShape()
    {
        int shapeType = (int) Random.Range(0, 2.99999f);
        int colourIndex = (int) Random.Range(0, 3.9999f);
        float height = Random.Range(-0.6f, 0.4f);

        GameObject shapeToSpawn = shapes[shapeType];
        shapeToSpawn.GetComponent<SpriteRenderer>().color = colours[colourIndex];

        var shapeSpawned = Instantiate(shapeToSpawn, new Vector2(2, height), Quaternion.identity);

        // maybe have it moving up and down later?
        shapeSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(gameSpeed, 0);
    }

    private void IncreaseSpeed()
    {
        gameSpeed -= 0.2f;
        if (gameSpeed < -2)
        {
            CancelInvoke("IncreaseSpeed");
        }
    }
}