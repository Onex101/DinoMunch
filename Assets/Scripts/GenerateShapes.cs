using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateShapes : MonoBehaviour
{
    [SerializeField] private GameObject[] shapes;
    private Color[] colours = { Color.red, Color.blue, Color.yellow, Color.green };
    private float lastX = -1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShape", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnShape()
    {
        int shapeType = (int) Random.Range(0, 2.99999f);
        int colourIndex = (int) Random.Range(0, 3.9999f);
        float height = Random.Range(-0.6f, 0);

        GameObject shapeToSpawn = shapes[shapeType];
        shapeToSpawn.GetComponent<SpriteRenderer>().color = colours[colourIndex];

        Instantiate(shapeToSpawn, new Vector2(lastX, height), Quaternion.identity);
        lastX += 0.2f;
    }
}
