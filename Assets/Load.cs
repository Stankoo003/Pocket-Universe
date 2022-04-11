using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    private void StartFirstScene() {
        SceneManager.LoadScene(1);
    
    }


    void Start()
    {
       
        Invoke("StartFirstScene", 1f);
    }

   
    void Update()
    {
        
    }
}
