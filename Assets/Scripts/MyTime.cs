using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTime : MonoBehaviour
    //시간 조정할 용도로 만들었는데 더이상 안쓰임
{
    public static float deltaTime = 0f;
    public static float timeScale = 1f;

    private void Update()
    {
        deltaTime = Time.deltaTime * timeScale;
    }
}
