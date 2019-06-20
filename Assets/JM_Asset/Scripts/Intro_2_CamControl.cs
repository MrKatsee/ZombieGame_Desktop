using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_2_CamControl : MonoBehaviour
{

    public Camera first_cam;
    public Camera second_cam;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        first_cam.enabled = true;
        second_cam.enabled = false;

        if(time > 2.0f)
        {
            first_cam.enabled = false;
            second_cam.enabled = true;
        }

    }
}
