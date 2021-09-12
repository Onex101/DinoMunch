using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    // Start is called before the first frame update
    int lives = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void removeLife(){
           if(lives >0){
                var life = transform.Find($"live{lives}").gameObject;
                Destroy(life);
                lives--;
           }
    }





    
}
