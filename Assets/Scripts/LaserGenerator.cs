using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;

public class LaserGenerator : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100;
    public Transform LaserFirePoint;
    public LineRenderer line;
    Transform m_transform;
    private float startTime;
    public Stopwatch timer;
    private GameObject laser;
    private GameObject laserContainer;
    
    // Start is called before the first frame update
    void Start() {
        laser = GameObject.Find("Laser");
        laserContainer = GameObject.Find("LaserContainer");
        DeactivateLaser();

        InvokeRepeating("DeactivateLaser", 15f, 15f);
        InvokeRepeating("ActivateLaser", 13f, 17f);
    }
    // Update is called once per frame
    void Update()
    {
       // Updating();
    }

    void Timer() {
        
        timer = new Stopwatch();

        timer.Start();

        //while(timer.Elapsed < new TimeSpan(100)) {

        //}
        timer.Stop();
    }

    void ActivateLaser() {
        laser = laserContainer.transform.Find("Laser").gameObject; 
        laser.GetComponent<Renderer>().enabled = true;
        
        line.materials[3] = line.materials[(int) UnityEngine.Random.Range(0, 3.9999f)];
        UnityEngine.Debug.Log("Activated Laser");
    }

    void DeactivateLaser() {
        laser.GetComponent<Renderer>().enabled = false;
        UnityEngine.Debug.Log("Deactivated Laser");
    }

    IEnumerator Updating() 
    {

        while(true)
        {
            yield return new WaitForSeconds(6f);

            ActivateLaser();
        }
    }

    IEnumerator UpdateCo() 
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);

            DeactivateLaser();
        }
    }
}
