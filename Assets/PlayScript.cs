using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    public AudioSource click;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playSound() {
        click.Play();
    }


}
