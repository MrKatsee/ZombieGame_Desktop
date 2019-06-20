using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessage : MonoBehaviour
{
    public static int msgNum = 0;
    /*
    public static void SystemMessageCreate(string msg)
    {
        msgNum++;

        GameObject systemMessage = new GameObject(msg, typeof(RectTransform));
        systemMessage.AddComponent<>
    }

    void Update()
    {
        RectTransform rTransform = GetComponent<RectTransform>();

        rTransform.position = new Vector3(0f, 100f - msgNum * 20f, 0f);
    }*/
}
