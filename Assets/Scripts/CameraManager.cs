using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //카메라를 관리하는 스크립트
    public GameObject player;

    void Update()
    {
        Vector3 vec = player.transform.position + new Vector3(0f, 20f, -20f);

        transform.position = vec;
    }
}
