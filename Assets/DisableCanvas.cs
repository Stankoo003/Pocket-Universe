using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvas : MonoBehaviour
{
    public GameObject Canvas1,coins;

    public void disableCanvas() {

        Canvas1.SetActive(false);
        
        coins.SetActive(true);
        
    }
    

    
}
