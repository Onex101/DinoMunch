using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;
using UnityEngine.UI;

public class LaserGenerator : MonoBehaviour
{
    public Transform LaserFirePoint;
    public LineRenderer line;
    Transform m_transform;
    private float startTime;
    public Stopwatch timer;
    private GameObject laser;
    private GameObject laserContainer;
    private int ChosenLaser;
    private String[] Lasers = {"RedLaser", "BlueLaser", "YellowLaser", "GreenLaser"};
    public Text text;
    
    // Start is called before the first frame update
    void Start() {
        laser = GameObject.Find("Laser");
        laserContainer = GameObject.Find("LaserContainer");
        DeactivateLaser();

        InvokeRepeating("DeactivateLaser", 15f, 8f);
        InvokeRepeating("WarnPlayer", 10f, 8f);
        InvokeRepeating("ActivateLaser", 13f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ActivateLaser() {
        laser = laserContainer.transform.Find("Laser").gameObject; 
        text.text = "";
        int laserIter = (int) UnityEngine.Random.Range(0, 3.9999f);
        line.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/" + Lasers[ChosenLaser] + ".mat");
        laser.SetActive(true);
        UnityEngine.Debug.Log("Activated Laser");
    }

    void DeactivateLaser() {
        laser.SetActive(false);
        UnityEngine.Debug.Log("Deactivated Laser");
    }

    void WarnPlayer() {
        ChosenLaser = (int) UnityEngine.Random.Range(0, 3.9999f);

        UnityEngine.Debug.Log("WARNING!! " + Lasers[ChosenLaser] + " approaching");
        text.text = "WARNING!! " + Lasers[ChosenLaser] + " approaching";
    }

}
