using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Between_cam : MonoBehaviour
{
    public Camera first_cam;
    public Camera second_cam;
    public Camera third_cam;
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
        third_cam.enabled = false;

        if (time > 8.0f)
        {
            first_cam.enabled = false;
            second_cam.enabled = true;
        }
        if (time > 16.0f)
        {
            second_cam.enabled = false;
            third_cam.enabled = true;
        }

    }
}
