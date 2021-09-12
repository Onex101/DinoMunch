using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistAudio : MonoBehaviour
{
    private static Transform backgroundMusic;
    private static AudioSource mainAudioSource;
    private static AudioSource jungleAudioSource;

    private void Awake()
    {
        if (backgroundMusic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            backgroundMusic = transform.Find("MainBGM");
            mainAudioSource = backgroundMusic.GetComponent<AudioSource>();
            jungleAudioSource = transform.Find("GameOverBGM").GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (mainAudioSource.isPlaying)
            {
                mainAudioSource.Stop();
                jungleAudioSource.Play();
            }
        }
        else if (!mainAudioSource.isPlaying)
        {
            jungleAudioSource.Stop();
            mainAudioSource.Play();
        }
    }
}
