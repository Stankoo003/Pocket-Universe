using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationCamera : MonoBehaviour
{
    public Transform Cam;
    public float xSpread;
    public float zSpread;
    private float yOffset = 800f;

    public GameObject start;
    private GameObject[] planets;
    public float[] Spread;

    public GameObject centerPoint;
    public float rotSpeed;
    private float zoomRadius;
    private float timer = 0.5f;
    private bool zoom = false;
    int s;
    public ParticleSystem particle;
    private bool drag = false;
    public Slider slider;



    public Text planetname;
    private string[] NaziviPlaneta;
    private bool once = true;

    public void enableZoom(){
    	zoom = true;
    	once = true;
    	
    }


    public void ChangeRotSpeed(float speed)
    {      
            rotSpeed = speed;
    }
    public void RightButton() {
    	/*int t=s-1;
    	if(t<0){
    		t=8;
    	}
    	
      	if(start.GetComponent<ChangeCoins>().planetFound(t)==1){
        	*/s--;
        	if (s < 0)
            	s = 8;   
        	ZoomIn();
		//}
    }
    public void LeftButton() {
    	/*int t=s+1;
    	if(t>8){
    		t=0;
    	}*/
    	//if(start.GetComponent<ChangeCoins>().planetFound(s+1)==1){
       	 	s++;
        	if (s > 8)
            	s = 0;
        	ZoomIn();
      //}
    }
    public void Travel() {
        start.GetComponent<ChangeCoins>().changePlanetNumber(s);
    }
    public void BeginDrag() {
        drag = true;
    }

    public void ChangeRotationRadius(int s) {
    	int mul=1;
        if (drag)
        {
        	if(s>=4 && s<=7){
        		mul=2;
        	}else{
        		mul=1;
        	}
            zoom = false;
            xSpread += slider.value * Time.deltaTime * 5*mul;
            zSpread += slider.value * Time.deltaTime * 5*mul;
        }
    }

    public void EndDrag()
    {
        slider.value = 0;
        drag = false;
       
    }





    void Start()
    {
    	NaziviPlaneta = new string[9];
        s = start.GetComponent<ChangeCoins>().returnNumber();
        planets = new GameObject[9];
        Spread = new float[9];
        if(s==0){
        	particle.maxParticles = 130;
       	}else{
			particle.maxParticles = 250;
       	}
        planets[0] = GameObject.Find("Mercury");
        planets[1] = GameObject.Find("Venus");
        planets[2] = GameObject.Find("Earth1");
        planets[3] = GameObject.Find("Mars");
        planets[4] = GameObject.Find("Jupiter");
        planets[5] = GameObject.Find("SphereSaturn");
        planets[6] = GameObject.Find("Uranus");
        planets[7] = GameObject.Find("Neptune");
        planets[8] = GameObject.Find("Pluto");

        Spread[0] = 7;
        Spread[1] = 15;
        Spread[2] = 20;
        Spread[3] = 12;
        Spread[4] = 130;
        Spread[5] = 150;
        Spread[6] = 50;
        Spread[7] = 55;
        Spread[8] = 4;

        NaziviPlaneta[0] = "Mercury";
        NaziviPlaneta[1] = "Venus";
        NaziviPlaneta[2] = "Earth";
        NaziviPlaneta[3] = "Mars";
        NaziviPlaneta[4] = "Jupiter";
        NaziviPlaneta[5] = "Saturn";
        NaziviPlaneta[6] = "Uranus";
        NaziviPlaneta[7] = "Neptune";
        NaziviPlaneta[8] = "Pluto";


        particle.Play(true);

       	ZoomIn();

        

        Cam.LookAt(centerPoint.transform);


    }

    public void ZoomIn() {
    	zoomRadius = Spread[s]*1.7f;
        zSpread = xSpread = zoomRadius*2.5f;
        
    }


    void Update()
    {
    	if(s==0){
        	particle.maxParticles = 130;
       	}else{
			particle.maxParticles = 250;
       	}
        ChangeRotationRadius(s);
        
        if (!Cam.GetComponent<TravelMode>().IsTravel()) {
            s = start.GetComponent<ChangeCoins>().returnNumber();

        }else{
        	ZoomIn();
        }
       	if (once)
        {
            ZoomIn();
            once = false;
        }

        centerPoint = planets[s];
        planetname.text = NaziviPlaneta[s];

        timer += Time.deltaTime * rotSpeed;
        Rotate();
        Cam.LookAt(centerPoint.transform);

        

        if (yOffset > 50)
        {
            yOffset -= Time.deltaTime % yOffset * 330;
        }
        else if (yOffset > 2)
        {
            yOffset -= Time.deltaTime % yOffset * 230;

        }

        if (xSpread > zoomRadius && zoom)
        {

            xSpread -= 130f * Time.deltaTime;
            zSpread -= 130f * Time.deltaTime;
        }
        if(xSpread < -zoomRadius && zoom){
			xSpread += 130f * Time.deltaTime;
            zSpread += 130f * Time.deltaTime;

        }

        


    }
    void Rotate()
    {

            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            Cam.position = pos + centerPoint.transform.position;
             
    }


    public void ChangeThePlanet()
    {
        this.zoom = true;
    }

}
