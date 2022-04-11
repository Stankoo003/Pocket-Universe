using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverPlacement : MonoBehaviour
{
  	Vector3 RoverZemlja;
  	public GameObject rover;
  	public GameObject zemlja;


   void Start(){
   		RoverZemlja = new Vector3(-0.01331119f,0.001953757f,0.006513824f);

   }


   public void Build(){   	

   		rover.transform.SetParent(zemlja.transform);
        rover.transform.position = rover.transform.parent.TransformPoint(RoverZemlja);

    }


}
