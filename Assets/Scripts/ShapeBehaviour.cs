using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // maybe have it moving up and down later?
        Vector3 horizontal = new Vector3(-0.5f, 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        if (transform.position.x < -2)
        {
            // Shape has gone offscreen to the left
            Destroy(gameObject);
        }
    }
}
