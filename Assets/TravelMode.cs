using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelMode : MonoBehaviour
{
    private bool isTravelOn = false;
    public GameObject stats;
    public GameObject travelcanvas;

    public void enableTravel() {
        stats.SetActive(false);
        travelcanvas.SetActive(true);
        isTravelOn = true;
        
    }
    public void disableTravel() {
        isTravelOn = false;
        travelcanvas.SetActive(false);
        stats.SetActive(true);
    }
    public bool IsTravel() {
        return isTravelOn;
    }

}


