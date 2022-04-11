using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject RorationObject;
    public float xSpread;
    public float zSpread;
    private float yOffset=0f;
    public Transform centerPoint;

    public float rotSpeed;
    public bool rotateClockwise;
    private float timer = 0.5f;
    private bool zoom=false;
    private Touch oneTouch;
    



    

    public void ChangeRotSpeed(float speed) {
        if (RorationObject.name == "Camera")
        {
            rotSpeed = speed;
        }
        
    
    }
    void Start() {
      
            
        
   
    }
  




    void Update()
    {
        timer += Time.deltaTime*rotSpeed;
        Rotate();
        





        /*if (xSpread > 30&&zoom) { 
            
           xSpread -= 100f * Time.deltaTime;
           zSpread -= 100f * Time.deltaTime;
          
        }
        */

        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                Application.Quit();
            }
        }
    }
    void Rotate() {
        



        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
        else {
            
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;

        }
        

    
    }
    

    public void ChangeThePlanet()
    {
        this.zoom = true;       
    }






}
