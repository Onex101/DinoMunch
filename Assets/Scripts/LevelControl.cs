using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private AudioSource[] bgm;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int currentLevel = 0;
    private int nextLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = backgrounds[0];
        bgm[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Testing level switch
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.sprite = backgrounds[nextLevel];
            bgm[currentLevel].Stop();
            bgm[nextLevel].Play();
            int tmp = currentLevel;
            currentLevel = nextLevel;
            nextLevel = tmp;
        }
        
    }
}
