﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(7f*Time.deltaTime, 0, 0, Space.Self);
    }
}
