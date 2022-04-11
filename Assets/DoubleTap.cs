using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleTap : MonoBehaviour
{

    private Touch touch;
    public GameObject Dialog;
    public GameObject Satelites,Rovers,SpaceStations;
    bool DialogOpened = false;
    void Start()
    {
        Dialog.SetActive(false);
        Satelites.SetActive(false);
        Rovers.SetActive(false);
        SpaceStations.SetActive(false);

    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Planets")
            {
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if (touch.tapCount == 2)
                    {
                        Dialog.SetActive(true);
                        DialogOpened = true;

                    }
                }
            }
        }

    }
    public void ExitFromBuild() {
        Dialog.SetActive(false);
        DialogOpened = false;
    }
    public void GoToPanel(GameObject panel){
    	panel.SetActive(true);
    	Dialog.SetActive(false);

    }
    public void ExitFromCurrent(GameObject current){
    	current.SetActive(false);
    	Dialog.SetActive(true);

    }



}
