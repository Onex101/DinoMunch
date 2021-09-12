using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAudio : MonoBehaviour
{
    private static Transform backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (backgroundMusic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            backgroundMusic = transform.Find("BGM");
        }
    }
}
