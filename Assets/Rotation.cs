  using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotation : MonoBehaviour
{
    public GameObject camera;
    public GameObject coins;
    public GameObject Travel;
    public Transform planet;
    private Touch oneTouch, touchToMove;
    public float i = 100f;
    private Vector3 touchPosWorld;


    void Start()
    {
        
        Travel.SetActive(false);
        coins.SetActive(false);
    }


    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == planet)
            {

                if (Input.touchCount == 1)
                {
                    oneTouch = Input.GetTouch(0);
                    if (oneTouch.phase == TouchPhase.Moved)
                    {

                        planet.transform.Rotate(0, 0, (oneTouch.deltaPosition.x * 7) * Time.deltaTime, Space.Self);
                    }

                }
                
            }


        }
        else {
            
            if (Input.touchCount == 1)
            {
                
                oneTouch = Input.GetTouch(0);
                if (oneTouch.phase == TouchPhase.Moved)
                {
                    camera.GetComponent<RotationCamera>().ChangeRotSpeed(oneTouch.deltaPosition.x*Time.deltaTime*7);
                }
            }
            else {
                
                camera.GetComponent<RotationCamera>().ChangeRotSpeed(5f*Time.deltaTime);

            }

        }
        
        planet.transform.Rotate(0, 0, i * Time.deltaTime, Space.Self);
    }
    






    
}
